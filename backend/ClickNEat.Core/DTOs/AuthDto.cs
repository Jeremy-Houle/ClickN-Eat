using System.ComponentModel.DataAnnotations;

namespace ClickNEat.Core.DTOs;

public record RegisterDto(
    [Required][MaxLength(100)] string Name,
    [Required][EmailAddress][MaxLength(200)] string Email,
    [Required][MinLength(8)][MaxLength(128)] string Password
);

public record LoginDto(
    [Required][EmailAddress][MaxLength(200)] string Email,
    [Required] string Password
);

public record AuthResponseDto(string Token, string Name, string Email, string Role, int Points, int TotalPointsEarned);
