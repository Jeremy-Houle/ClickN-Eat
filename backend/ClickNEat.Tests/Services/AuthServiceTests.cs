using ClickNEat.API.Services;
using ClickNEat.Core.DTOs;
using ClickNEat.Core.Models;
using Microsoft.Extensions.Configuration;

namespace ClickNEat.Tests.Services;

public class AuthServiceTests
{
    private static IConfiguration CreateConfig() =>
        new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["Jwt:Secret"] = "test-secret-key-that-is-at-least-32-characters",
            ["Jwt:Issuer"] = "TestIssuer",
            ["Jwt:Audience"] = "TestAudience"
        }).Build();

    [Fact]
    public async Task Register_ValidDto_ReturnsOkWithToken()
    {
        using var db = TestDbFactory.Create();
        var service = new AuthService(db, CreateConfig());

        var result = await service.RegisterAsync(new RegisterDto("Alice", "alice@test.com", "password123"));

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value?.Token);
        Assert.Equal("alice@test.com", result.Value?.Email);
    }

    [Fact]
    public async Task Register_DuplicateEmail_ReturnsConflict()
    {
        using var db = TestDbFactory.Create();
        db.Users.Add(new User { Id = 1, Name = "Alice", Email = "alice@test.com", PasswordHash = "hash" });
        await db.SaveChangesAsync();

        var service = new AuthService(db, CreateConfig());
        var result = await service.RegisterAsync(new RegisterDto("Alice2", "alice@test.com", "password123"));

        Assert.False(result.IsSuccess);
        Assert.Equal(409, result.StatusCode);
    }

    [Fact]
    public async Task Login_ValidCredentials_ReturnsOkWithToken()
    {
        using var db = TestDbFactory.Create();
        var hash = BCrypt.Net.BCrypt.HashPassword("password123");
        db.Users.Add(new User { Id = 1, Name = "Alice", Email = "alice@test.com", PasswordHash = hash, IsActive = true });
        await db.SaveChangesAsync();

        var service = new AuthService(db, CreateConfig());
        var result = await service.LoginAsync(new LoginDto("alice@test.com", "password123"));

        Assert.True(result.IsSuccess);
        Assert.NotNull(result.Value?.Token);
    }

    [Fact]
    public async Task Login_WrongPassword_ReturnsUnauthorized()
    {
        using var db = TestDbFactory.Create();
        var hash = BCrypt.Net.BCrypt.HashPassword("correct");
        db.Users.Add(new User { Id = 1, Name = "Alice", Email = "alice@test.com", PasswordHash = hash });
        await db.SaveChangesAsync();

        var service = new AuthService(db, CreateConfig());
        var result = await service.LoginAsync(new LoginDto("alice@test.com", "wrong"));

        Assert.False(result.IsSuccess);
        Assert.Equal(401, result.StatusCode);
    }

    [Fact]
    public async Task Login_InactiveUser_ReturnsForbidden()
    {
        using var db = TestDbFactory.Create();
        var hash = BCrypt.Net.BCrypt.HashPassword("password123");
        db.Users.Add(new User { Id = 1, Name = "Alice", Email = "alice@test.com", PasswordHash = hash, IsActive = false });
        await db.SaveChangesAsync();

        var service = new AuthService(db, CreateConfig());
        var result = await service.LoginAsync(new LoginDto("alice@test.com", "password123"));

        Assert.False(result.IsSuccess);
        Assert.Equal(403, result.StatusCode);
    }
}
