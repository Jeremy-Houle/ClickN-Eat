namespace ClickNEat.Core.DTOs;

public record CreateOrderDto(
    string CustomerName,
    string CustomerEmail,
    string CustomerPhone,
    List<CreateOrderItemDto> Items
);

public record CreateOrderItemDto(
    int MenuItemId,
    int Quantity
);

public record UpdateOrderStatusDto(string Status);
