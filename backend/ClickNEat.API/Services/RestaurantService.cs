using ClickNEat.API.Data;
using ClickNEat.Core.Common;
using ClickNEat.Core.DTOs;
using ClickNEat.Core.Interfaces;
using ClickNEat.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ClickNEat.API.Services;

public class RestaurantService(AppDbContext db) : IRestaurantService
{
    public async Task<List<Restaurant>> GetAllAsync() =>
        await db.Restaurants.ToListAsync();

    public async Task<Restaurant?> GetByIdAsync(int id) =>
        await db.Restaurants.FindAsync(id);

    public async Task<ServiceResult<Restaurant>> UpdateAsync(int id, UpdateRestaurantDto dto)
    {
        var restaurant = await db.Restaurants.FindAsync(id);
        if (restaurant is null) return ServiceResult<Restaurant>.NotFound();

        restaurant.Name = dto.Name;
        restaurant.Description = dto.Description;
        restaurant.CoverImageUrl = dto.CoverImageUrl ?? restaurant.CoverImageUrl;
        restaurant.LogoUrl = dto.LogoUrl ?? restaurant.LogoUrl;
        restaurant.AccentColor = dto.AccentColor ?? restaurant.AccentColor;

        await db.SaveChangesAsync();
        return ServiceResult<Restaurant>.Ok(restaurant);
    }
}
