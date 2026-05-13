using ClickNEat.API.Data;
using ClickNEat.Core.Common;
using ClickNEat.Core.DTOs;
using ClickNEat.Core.Interfaces;
using ClickNEat.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ClickNEat.API.Services;

public class OrderService(AppDbContext db) : IOrderService
{
    public async Task<PagedResult<Order>> GetMyAsync(int userId, int page, int pageSize)
    {
        var query = db.Orders
            .Include(o => o.Items)
            .Where(o => o.UserId == userId)
            .OrderByDescending(o => o.CreatedAt);

        var total = await query.CountAsync();
        var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PagedResult<Order>(items, total, page, pageSize);
    }

    public async Task<PagedResult<Order>> GetAllAsync(int page, int pageSize)
    {
        var query = db.Orders
            .Include(o => o.Items)
            .OrderByDescending(o => o.CreatedAt);

        var total = await query.CountAsync();
        var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return new PagedResult<Order>(items, total, page, pageSize);
    }

    public async Task<ServiceResult<Order>> GetByIdAsync(int id, int userId, bool isAdmin)
    {
        var order = await db.Orders.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == id);
        if (order is null) return ServiceResult<Order>.NotFound();
        if (!isAdmin && order.UserId != userId) return ServiceResult<Order>.Forbidden();
        return ServiceResult<Order>.Ok(order);
    }

    public async Task<ServiceResult<CreateOrderResultDto>> CreateAsync(CreateOrderDto dto, int userId)
    {
        var user = await db.Users.FindAsync(userId);
        if (user is null) return ServiceResult<CreateOrderResultDto>.Unauthorized();

        if (dto.OrderType == "Delivery" && string.IsNullOrWhiteSpace(dto.DeliveryAddress))
            return ServiceResult<CreateOrderResultDto>.Fail("errors.order.deliveryAddressRequired");

        var order = new Order
        {
            CustomerName = dto.CustomerName,
            CustomerEmail = dto.CustomerEmail,
            CustomerPhone = dto.CustomerPhone ?? "",
            PaidWithPoints = dto.UsePoints,
            UserId = userId,
            OrderType = dto.OrderType == "Delivery" ? "Delivery" : "Pickup",
            DeliveryAddress = dto.DeliveryAddress?.Trim() ?? "",
            DeliveryNote = dto.DeliveryNote?.Trim() ?? "",
        };

        int? orderRestaurantId = null;
        foreach (var itemDto in dto.Items)
        {
            var menuItem = await db.MenuItems.FindAsync(itemDto.MenuItemId);
            if (menuItem is null || !menuItem.IsAvailable)
                return ServiceResult<CreateOrderResultDto>.Fail("errors.order.itemUnavailable");

            if (orderRestaurantId is null)
                orderRestaurantId = menuItem.RestaurantId;
            else if (menuItem.RestaurantId != orderRestaurantId)
                return ServiceResult<CreateOrderResultDto>.Fail("errors.order.mixedRestaurants");

            order.Items.Add(new OrderItem
            {
                MenuItemId = menuItem.Id,
                MenuItemName = menuItem.Name,
                Quantity = itemDto.Quantity,
                UnitPrice = menuItem.Price
            });
        }

        var pointsValue = (int)(order.Total * 100);

        if (dto.UsePoints)
        {
            if (user.Points < pointsValue)
                return ServiceResult<CreateOrderResultDto>.Fail("errors.order.insufficientPoints");
            user.Points -= pointsValue;
        }
        else
        {
            user.Points += pointsValue;
            user.TotalPointsEarned += pointsValue;
        }

        db.Orders.Add(order);
        await db.SaveChangesAsync();

        return ServiceResult<CreateOrderResultDto>.Ok(
            new CreateOrderResultDto(order, user.Points, user.TotalPointsEarned));
    }

    public async Task<ServiceResult<Order>> UpdateStatusAsync(int id, string status)
    {
        var order = await db.Orders.FindAsync(id);
        if (order is null) return ServiceResult<Order>.NotFound();

        if (!Enum.TryParse<OrderStatus>(status, true, out var parsed))
            return ServiceResult<Order>.Fail("errors.order.invalidStatus");

        order.Status = parsed;
        await db.SaveChangesAsync();
        return ServiceResult<Order>.Ok(order);
    }
}
