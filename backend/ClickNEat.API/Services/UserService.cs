using ClickNEat.API.Data;
using ClickNEat.Core.Common;
using ClickNEat.Core.DTOs;
using ClickNEat.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClickNEat.API.Services;

public class UserService(AppDbContext db) : IUserService
{
    public async Task<ServiceResult<ProfileUpdateResultDto>> UpdateProfileAsync(int userId, UpdateProfileDto dto)
    {
        var user = await db.Users.FindAsync(userId);
        if (user is null) return ServiceResult<ProfileUpdateResultDto>.NotFound();

        var normalizedEmail = dto.Email.ToLower().Trim();
        if (!string.Equals(normalizedEmail, user.Email, StringComparison.OrdinalIgnoreCase) &&
            await db.Users.AnyAsync(u => u.Email == normalizedEmail && u.Id != userId))
            return ServiceResult<ProfileUpdateResultDto>.Conflict("errors.user.emailTaken");

        user.Name = dto.Name.Trim();
        user.Email = normalizedEmail;
        await db.SaveChangesAsync();

        return ServiceResult<ProfileUpdateResultDto>.Ok(new ProfileUpdateResultDto(user.Name, user.Email));
    }

    public async Task<ServiceResult<bool>> UpdatePasswordAsync(int userId, UpdatePasswordDto dto)
    {
        var user = await db.Users.FindAsync(userId);
        if (user is null) return ServiceResult<bool>.NotFound();

        if (!BCrypt.Net.BCrypt.Verify(dto.CurrentPassword, user.PasswordHash))
            return ServiceResult<bool>.Fail("errors.user.wrongPassword");

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
        await db.SaveChangesAsync();
        return ServiceResult<bool>.Ok(true);
    }
}
