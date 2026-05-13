using ClickNEat.API.Data;
using ClickNEat.Core.Common;
using ClickNEat.Core.DTOs;
using ClickNEat.Core.Interfaces;
using ClickNEat.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ClickNEat.API.Services;

public class AdminService(AppDbContext db) : IAdminService
{
    public async Task<AdminStatsDto> GetStatsAsync()
    {
        var today = DateTime.UtcNow.Date;
        var tomorrow = today.AddDays(1);

        var todayOrderCount = await db.Orders.CountAsync(o => o.CreatedAt >= today && o.CreatedAt < tomorrow);
        var todayRevenue = await db.Orders
            .Where(o => o.CreatedAt >= today && o.CreatedAt < tomorrow && !o.PaidWithPoints)
            .SelectMany(o => o.Items)
            .SumAsync(i => (decimal?)i.UnitPrice * i.Quantity) ?? 0m;

        var totalOrderCount = await db.Orders.CountAsync();
        var totalRevenue = await db.Orders
            .Where(o => !o.PaidWithPoints)
            .SelectMany(o => o.Items)
            .SumAsync(i => (decimal?)i.UnitPrice * i.Quantity) ?? 0m;

        var pendingCount = await db.Orders.CountAsync(o => o.Status == OrderStatus.Pending);

        var topItem = await db.Orders
            .SelectMany(o => o.Items)
            .GroupBy(i => i.MenuItemName)
            .Select(g => new { Name = g.Key, Count = g.Sum(i => i.Quantity) })
            .OrderByDescending(g => g.Count)
            .FirstOrDefaultAsync();

        var totalUsers = await db.Users.CountAsync(u => u.Role == "Customer");

        return new AdminStatsDto(
            todayOrderCount,
            todayRevenue,
            totalOrderCount,
            totalRevenue,
            pendingCount,
            topItem?.Name ?? "—",
            totalUsers
        );
    }

    public async Task<PagedResult<UserSummaryDto>> GetUsersAsync(int page, int pageSize)
    {
        var query = db.Users.OrderByDescending(u => u.CreatedAt);
        var total = await query.CountAsync();
        var items = await query
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(u => new UserSummaryDto(u.Id, u.Name, u.Email, u.Role, u.Points, u.TotalPointsEarned, u.IsActive, u.CreatedAt))
            .ToListAsync();
        return new PagedResult<UserSummaryDto>(items, total, page, pageSize);
    }

    public async Task<ServiceResult<ToggleUserResultDto>> ToggleUserStatusAsync(int id, int adminId)
    {
        if (adminId == id)
            return ServiceResult<ToggleUserResultDto>.Fail("errors.admin.cannotModifySelf");

        var user = await db.Users.FindAsync(id);
        if (user is null) return ServiceResult<ToggleUserResultDto>.NotFound();

        user.IsActive = !user.IsActive;
        await db.SaveChangesAsync();
        return ServiceResult<ToggleUserResultDto>.Ok(new ToggleUserResultDto(user.Id, user.IsActive));
    }

    public async Task<ServiceResult<bool>> DeleteUserAsync(int id, int adminId)
    {
        if (adminId == id)
            return ServiceResult<bool>.Fail("errors.admin.cannotDeleteSelf");

        var user = await db.Users.FindAsync(id);
        if (user is null) return ServiceResult<bool>.NotFound();

        await db.Orders
            .Where(o => o.UserId == id)
            .ExecuteUpdateAsync(s => s.SetProperty(o => o.UserId, (int?)null));

        db.Users.Remove(user);
        await db.SaveChangesAsync();
        return ServiceResult<bool>.Ok(true);
    }
}
