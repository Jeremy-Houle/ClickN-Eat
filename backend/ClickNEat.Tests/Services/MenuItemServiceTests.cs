using ClickNEat.API.Services;
using ClickNEat.Core.DTOs;
using ClickNEat.Core.Models;

namespace ClickNEat.Tests.Services;

public class MenuItemServiceTests
{
    private static async Task<ClickNEat.API.Data.AppDbContext> SeedAsync()
    {
        var db = TestDbFactory.Create();
        db.MenuItems.AddRange(
            new MenuItem { Id = 1, Name = "Burger", Category = "Burgers", Price = 12m, IsAvailable = true, RestaurantId = 1 },
            new MenuItem { Id = 2, Name = "Pizza", Category = "Pizzas", Price = 14m, IsAvailable = true, RestaurantId = 1 },
            new MenuItem { Id = 3, Name = "Hidden", Category = "Burgers", Price = 10m, IsAvailable = false, RestaurantId = 1 },
            new MenuItem { Id = 4, Name = "Salad", Category = "Salades", Price = 9m, IsAvailable = true, RestaurantId = 2 }
        );
        await db.SaveChangesAsync();
        return db;
    }

    [Fact]
    public async Task GetAll_ExcludesUnavailableByDefault()
    {
        using var db = await SeedAsync();
        var service = new MenuItemService(db);

        var result = await service.GetAllAsync(restaurantId: null, category: null, includeAll: false);

        Assert.DoesNotContain(result, i => !i.IsAvailable);
    }

    [Fact]
    public async Task GetAll_IncludesUnavailableWhenIncludeAll()
    {
        using var db = await SeedAsync();
        var service = new MenuItemService(db);

        var result = await service.GetAllAsync(restaurantId: null, category: null, includeAll: true);

        Assert.Contains(result, i => !i.IsAvailable);
    }

    [Fact]
    public async Task GetAll_FiltersByRestaurant()
    {
        using var db = await SeedAsync();
        var service = new MenuItemService(db);

        var result = await service.GetAllAsync(restaurantId: 2, category: null, includeAll: false);

        Assert.All(result, i => Assert.Equal(2, i.RestaurantId));
    }

    [Fact]
    public async Task GetAll_FiltersByCategory()
    {
        using var db = await SeedAsync();
        var service = new MenuItemService(db);

        var result = await service.GetAllAsync(restaurantId: null, category: "Pizzas", includeAll: false);

        Assert.All(result, i => Assert.Equal("Pizzas", i.Category));
    }

    [Fact]
    public async Task Create_PersistsItem()
    {
        using var db = TestDbFactory.Create();
        var service = new MenuItemService(db);
        var dto = new CreateMenuItemDto("Nuggets", "Crispy", 8.99m, "Poulet", null, true, "", 1);

        var item = await service.CreateAsync(dto);

        Assert.True(item.Id > 0);
        Assert.Equal("Nuggets", item.Name);
    }

    [Fact]
    public async Task Update_UnknownId_ReturnsNotFound()
    {
        using var db = TestDbFactory.Create();
        var service = new MenuItemService(db);
        var dto = new UpdateMenuItemDto("X", "X", 1m, "X", null, true);

        var result = await service.UpdateAsync(999, dto);

        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
    }

    [Fact]
    public async Task Delete_UnknownId_ReturnsNotFound()
    {
        using var db = TestDbFactory.Create();
        var service = new MenuItemService(db);

        var result = await service.DeleteAsync(999);

        Assert.False(result.IsSuccess);
        Assert.Equal(404, result.StatusCode);
    }
}
