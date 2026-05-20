using ClickNEat.API.Services;
using ClickNEat.Core.DTOs;
using ClickNEat.Core.Models;

namespace ClickNEat.Tests.Services;

public class UserServiceTests
{
    private static async Task<ClickNEat.API.Data.AppDbContext> SeedAsync()
    {
        var db = TestDbFactory.Create();
        db.Users.AddRange(
            new User { Id = 1, Name = "Alice", Email = "alice@test.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("pass123") },
            new User { Id = 2, Name = "Bob", Email = "bob@test.com", PasswordHash = "h" }
        );
        await db.SaveChangesAsync();
        return db;
    }

    [Fact]
    public async Task UpdateProfile_Success()
    {
        using var db = await SeedAsync();
        var service = new UserService(db);

        var result = await service.UpdateProfileAsync(1, new UpdateProfileDto("Alice Updated", "alice-new@test.com"));

        Assert.True(result.IsSuccess);
        Assert.Equal("Alice Updated", result.Value!.Name);
        Assert.Equal("alice-new@test.com", result.Value.Email);
    }

    [Fact]
    public async Task UpdateProfile_EmailTakenByOtherUser_ReturnsConflict()
    {
        using var db = await SeedAsync();
        var service = new UserService(db);

        var result = await service.UpdateProfileAsync(1, new UpdateProfileDto("Alice", "bob@test.com"));

        Assert.False(result.IsSuccess);
        Assert.Equal(409, result.StatusCode);
    }

    [Fact]
    public async Task UpdateProfile_SameEmailAsOwn_Succeeds()
    {
        using var db = await SeedAsync();
        var service = new UserService(db);

        var result = await service.UpdateProfileAsync(1, new UpdateProfileDto("Alice Renamed", "alice@test.com"));

        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task UpdatePassword_WrongCurrentPassword_ReturnsFail()
    {
        using var db = await SeedAsync();
        var service = new UserService(db);

        var result = await service.UpdatePasswordAsync(1, new UpdatePasswordDto("wrongpass", "newpassword"));

        Assert.False(result.IsSuccess);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public async Task UpdatePassword_CorrectPassword_Succeeds()
    {
        using var db = await SeedAsync();
        var service = new UserService(db);

        var result = await service.UpdatePasswordAsync(1, new UpdatePasswordDto("pass123", "newpassword123"));

        Assert.True(result.IsSuccess);
        var user = await db.Users.FindAsync(1);
        Assert.True(BCrypt.Net.BCrypt.Verify("newpassword123", user!.PasswordHash));
    }
}
