using System.ComponentModel.DataAnnotations;

namespace ClickNEat.Core.DTOs;

public record UpdateRestaurantDto(
    [Required][MaxLength(200)] string Name,
    [Required][MaxLength(500)] string Description,
    [MaxLength(2000)] string? CoverImageUrl,
    [MaxLength(2000)] string? LogoUrl,
    [MaxLength(20)] string? AccentColor
);
