using System.ComponentModel.DataAnnotations;

namespace ClickNEat.Core.DTOs;

public record CreateOrderDto(
    [Required][MaxLength(100)] string CustomerName,
    [Required][EmailAddress][MaxLength(200)] string CustomerEmail,
    [MaxLength(50)] string? CustomerPhone,
    [Required][MinLength(1)] List<CreateOrderItemDto> Items,
    bool UsePoints = false,
    string OrderType = "Pickup",
    [MaxLength(500)] string? DeliveryAddress = null,
    [MaxLength(1000)] string? DeliveryNote = null
);

public record CreateOrderItemDto(
    [Range(1, int.MaxValue)] int MenuItemId,
    [Range(1, 9999)] int Quantity
);

public record UpdateOrderStatusDto([Required] string Status);

public record CreateOrderResultDto(ClickNEat.Core.Models.Order Order, int NewPoints, int NewTotalPointsEarned);
