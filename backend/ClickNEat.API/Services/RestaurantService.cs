using ClickNEat.API.Data;
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
}
