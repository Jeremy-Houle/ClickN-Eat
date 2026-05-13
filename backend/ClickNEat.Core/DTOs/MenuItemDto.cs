using System.ComponentModel.DataAnnotations;

namespace ClickNEat.Core.DTOs;

public record CreateMenuItemDto(
    [Required][MaxLength(200)] string Name,
    [Required][MaxLength(1000)] string Description,
    [Range(0.01, 9999.99)] decimal Price,
    [Required][MaxLength(100)] string Category,
    [MaxLength(2000)] string? ImageUrl,
    bool IsAvailable,
    string Tags = "",
    int RestaurantId = 1
);

public record UpdateMenuItemDto(
    [Required][MaxLength(200)] string Name,
    [Required][MaxLength(1000)] string Description,
    [Range(0.01, 9999.99)] decimal Price,
    [Required][MaxLength(100)] string Category,
    [MaxLength(2000)] string? ImageUrl,
    bool IsAvailable,
    string Tags = ""
);
