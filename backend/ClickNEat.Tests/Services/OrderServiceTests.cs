using ClickNEat.API.Services;
using ClickNEat.Core.DTOs;
using ClickNEat.Core.Models;

namespace ClickNEat.Tests.Services;

public class OrderServiceTests
{
    private static async Task<ClickNEat.API.Data.AppDbContext> SeedAsync()
    {
        var db = TestDbFactory.Create();
        db.Users.AddRange(
            new User { Id = 10, Name = "User A", Email = "a@test.com", PasswordHash = "h", Points = 1000, TotalPointsEarned = 1000 },
            new User { Id = 11, Name = "User B", Email = "b@test.com", PasswordHash = "h" }
        );
        db.MenuItems.AddRange(
            new MenuItem { Id = 100, Name = "Burger", Price = 10m, IsAvailable = true, RestaurantId = 1 },
            new MenuItem { Id = 101, Name = "Pizza", Price = 12m, IsAvailable = true, RestaurantId = 2 },
            new MenuItem { Id = 102, Name = "Frites", Price = 4m, IsAvailable = false, RestaurantId = 1 }
        );
        db.Orders.Add(new Order
        {
            Id = 200,
            UserId = 10,
            CustomerName = "User A",
            CustomerEmail = "a@test.com",
            Items = [new OrderItem { MenuItemId = 100, MenuItemName = "Burger", Quantity = 1, UnitPrice = 10m }]
        });
        await db.SaveChangesAsync();
        return db;
    }

    [Fact]
    public async Task GetById_UserOwnsOrder_ReturnsOk()
    {
        using var db = await SeedAsync();
        var service = new OrderService(db);

        var result = await service.GetByIdAsync(200, userId: 10, isAdmin: false);

        Assert.True(result.IsSuccess);
        Assert.Equal(200, result.Value!.Id);
    }

    [Fact]
    public async Task GetById_UserDoesNotOwnOrder_ReturnsForbidden()
    {
        using var db = await SeedAsync();
        var service = new OrderService(db);

        var result = await service.GetByIdAsync(200, userId: 11, isAdmin: false);

        Assert.False(result.IsSuccess);
        Assert.Equal(403, result.StatusCode);
    }

    [Fact]
    public async Task GetById_AdminCanAccessAnyOrder()
    {
        using var db = await SeedAsync();
        var service = new OrderService(db);

        var result = await service.GetByIdAsync(200, userId: 11, isAdmin: true);

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task Create_MixedRestaurants_ReturnsFail()
    {
        using var db = await SeedAsync();
        var service = new OrderService(db);
        var dto = new CreateOrderDto("User A", "a@test.com", null,
            [new CreateOrderItemDto(100, 1), new CreateOrderItemDto(101, 1)]);

        var result = await service.CreateAsync(dto, userId: 10);

        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public async Task Create_UnavailableItem_ReturnsFail()
    {
        using var db = await SeedAsync();
        var service = new OrderService(db);
        var dto = new CreateOrderDto("User A", "a@test.com", null,
            [new CreateOrderItemDto(102, 1)]);

        var result = await service.CreateAsync(dto, userId: 10);

        Assert.False(result.IsSuccess);
    }

    [Fact]
    public async Task Create_WithPoints_DeductsFromUserBalance()
    {
        using var db = await SeedAsync();
        var service = new OrderService(db);
        var dto = new CreateOrderDto("User A", "a@test.com", null,
            [new CreateOrderItemDto(100, 1)], UsePoints: true);

        var result = await service.CreateAsync(dto, userId: 10);

        Assert.True(result.IsSuccess);
        Assert.True(result.Value!.NewPoints < 1000);
    }

    [Fact]
    public async Task Create_WithoutPoints_AddsToUserBalance()
    {
        using var db = await SeedAsync();
        var service = new OrderService(db);
        var dto = new CreateOrderDto("User A", "a@test.com", null,
            [new CreateOrderItemDto(100, 1)]);

        var result = await service.CreateAsync(dto, userId: 10);

        Assert.True(result.IsSuccess);
        Assert.True(result.Value!.NewPoints > 1000);
    }

    [Fact]
    public async Task Create_InsufficientPoints_ReturnsFail()
    {
        using var db = await SeedAsync();
        var service = new OrderService(db);
        // User B has 0 points, order costs 1200 points
        var dto = new CreateOrderDto("User B", "b@test.com", null,
            [new CreateOrderItemDto(101, 1)], UsePoints: true);

        var result = await service.CreateAsync(dto, userId: 11);

        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public async Task UpdateStatus_InvalidStatus_ReturnsFail()
    {
        using var db = await SeedAsync();
        var service = new OrderService(db);

        var result = await service.UpdateStatusAsync(200, "NotAStatus");

        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
    }
}
