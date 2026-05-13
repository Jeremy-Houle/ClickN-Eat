using System.ComponentModel.DataAnnotations;

namespace ClickNEat.Core.DTOs;

public record UpdateProfileDto(
    [Required][MaxLength(100)] string Name,
    [Required][EmailAddress][MaxLength(200)] string Email
);

public record UpdatePasswordDto(
    [Required] string CurrentPassword,
    [Required][MinLength(8)][MaxLength(128)] string NewPassword
);

public record ProfileUpdateResultDto(string Name, string Email);

public record UserSummaryDto(
    int Id,
    string Name,
    string Email,
    string Role,
    int Points,
    int TotalPointsEarned,
    bool IsActive,
    DateTime CreatedAt
);
