using ClickNEat.API.Data;
using ClickNEat.Core.Common;
using ClickNEat.Core.DTOs;
using ClickNEat.Core.Interfaces;
using ClickNEat.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClickNEat.API.Services;

public class AuthService(AppDbContext db, IConfiguration config) : IAuthService
{
    public async Task<ServiceResult<AuthResponseDto>> RegisterAsync(RegisterDto dto)
    {
        var normalizedEmail = dto.Email.ToLower().Trim();

        if (await db.Users.AnyAsync(u => u.Email == normalizedEmail))
            return ServiceResult<AuthResponseDto>.Conflict("errors.auth.emailTaken");

        var user = new User
        {
            Name = dto.Name,
            Email = normalizedEmail,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Role = "Customer"
        };

        db.Users.Add(user);
        await db.SaveChangesAsync();

        return ServiceResult<AuthResponseDto>.Ok(BuildResponse(user));
    }

    public async Task<ServiceResult<AuthResponseDto>> LoginAsync(LoginDto dto)
    {
        var normalizedEmail = dto.Email.ToLower().Trim();
        var user = await db.Users.FirstOrDefaultAsync(u => u.Email == normalizedEmail);

        if (user is null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            return ServiceResult<AuthResponseDto>.Unauthorized("errors.auth.invalidCredentials");

        if (!user.IsActive)
            return ServiceResult<AuthResponseDto>.Fail("errors.auth.accountDisabled", 403);

        return ServiceResult<AuthResponseDto>.Ok(BuildResponse(user));
    }

    private AuthResponseDto BuildResponse(User user)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Secret"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Role, user.Role),
        };

        var token = new JwtSecurityToken(
            issuer: config["Jwt:Issuer"],
            audience: config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: creds
        );

        return new AuthResponseDto(
            new JwtSecurityTokenHandler().WriteToken(token),
            user.Name,
            user.Email,
            user.Role,
            user.Points,
            user.TotalPointsEarned
        );
    }
}
