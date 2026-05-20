using ClickNEat.API.Services;
using ClickNEat.Core.Models;

namespace ClickNEat.Tests.Services;

public class AdminServiceTests
{
    private static async Task<ClickNEat.API.Data.AppDbContext> SeedAsync()
    {
        var db = TestDbFactory.Create();
        db.Users.AddRange(
            new User { Id = 1, Name = "Admin", Email = "admin@test.com", PasswordHash = "h", Role = "Admin" },
            new User { Id = 2, Name = "Customer", Email = "cust@test.com", PasswordHash = "h", Role = "Customer", IsActive = true }
        );
        db.Orders.Add(new Order
        {
            Id = 1, UserId = 2, CustomerName = "Customer", CustomerEmail = "cust@test.com",
            Items = [new OrderItem { MenuItemId = 1, MenuItemName = "Burger", Quantity = 2, UnitPrice = 10m }]
        });
        await db.SaveChangesAsync();
        return db;
    }

    [Fact]
    public async Task ToggleUserStatus_AdminCannotToggleOwnAccount()
    {
        using var db = await SeedAsync();
        var service = new AdminService(db);

        var result = await service.ToggleUserStatusAsync(id: 1, adminId: 1);

        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public async Task ToggleUserStatus_TogglesActiveFlag()
    {
        using var db = await SeedAsync();
        var service = new AdminService(db);

        var result = await service.ToggleUserStatusAsync(id: 2, adminId: 1);

        Assert.True(result.IsSuccess);
        Assert.False(result.Value!.IsActive); // was true, now false
    }

    [Fact]
    public async Task DeleteUser_AdminCannotDeleteOwnAccount()
    {
        using var db = await SeedAsync();
        var service = new AdminService(db);

        var result = await service.DeleteUserAsync(id: 1, adminId: 1);

        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
    }

    // ExecuteUpdateAsync is a bulk-update operation not supported by the InMemory provider.
    // This behavior (nullify order.UserId before user deletion) is verified against SQL Server.
    [Fact(Skip = "ExecuteUpdateAsync is not supported by InMemory. Run against SQL Server for integration coverage.")]
    public Task DeleteUser_NullifiesOrderUserId() => Task.CompletedTask;

    [Fact]
    public async Task GetStats_ReturnsCorrectTotals()
    {
        using var db = await SeedAsync();
        var service = new AdminService(db);

        var stats = await service.GetStatsAsync();

        Assert.Equal(1, stats.TotalOrderCount);
        Assert.Equal(1, stats.TotalUsers);
        Assert.Equal("Burger", stats.TopItem);
    }
}
