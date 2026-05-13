using ClickNEat.API.Data;
using ClickNEat.Core.Common;
using ClickNEat.Core.DTOs;
using ClickNEat.Core.Interfaces;
using ClickNEat.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ClickNEat.API.Services;

public class MenuItemService(AppDbContext db) : IMenuItemService
{
    public async Task<List<MenuItem>> GetAllAsync(int? restaurantId, string? category, bool includeAll)
    {
        IQueryable<MenuItem> query = db.MenuItems;
        if (!includeAll) query = query.Where(m => m.IsAvailable);
        if (restaurantId.HasValue) query = query.Where(m => m.RestaurantId == restaurantId.Value);
        if (!string.IsNullOrWhiteSpace(category)) query = query.Where(m => m.Category == category);
        return await query.ToListAsync();
    }

    public async Task<MenuItem?> GetByIdAsync(int id) =>
        await db.MenuItems.FindAsync(id);

    public async Task<List<string>> GetCategoriesAsync(int? restaurantId, bool includeAll)
    {
        IQueryable<MenuItem> query = db.MenuItems;
        if (!includeAll) query = query.Where(m => m.IsAvailable);
        if (restaurantId.HasValue) query = query.Where(m => m.RestaurantId == restaurantId.Value);
        return await query.Select(m => m.Category).Distinct().ToListAsync();
    }

    public async Task<MenuItem> CreateAsync(CreateMenuItemDto dto)
    {
        var item = new MenuItem
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            Category = dto.Category,
            ImageUrl = dto.ImageUrl ?? "",
            IsAvailable = dto.IsAvailable,
            Tags = dto.Tags,
            RestaurantId = dto.RestaurantId
        };

        db.MenuItems.Add(item);
        await db.SaveChangesAsync();
        return item;
    }

    public async Task<ServiceResult<bool>> UpdateAsync(int id, UpdateMenuItemDto dto)
    {
        var item = await db.MenuItems.FindAsync(id);
        if (item is null) return ServiceResult<bool>.NotFound();

        item.Name = dto.Name;
        item.Description = dto.Description;
        item.Price = dto.Price;
        item.Category = dto.Category;
        item.ImageUrl = dto.ImageUrl ?? "";
        item.IsAvailable = dto.IsAvailable;
        item.Tags = dto.Tags;

        await db.SaveChangesAsync();
        return ServiceResult<bool>.Ok(true);
    }

    public async Task<ServiceResult<bool>> DeleteAsync(int id)
    {
        var item = await db.MenuItems.FindAsync(id);
        if (item is null) return ServiceResult<bool>.NotFound();

        db.MenuItems.Remove(item);
        await db.SaveChangesAsync();
        return ServiceResult<bool>.Ok(true);
    }
}
