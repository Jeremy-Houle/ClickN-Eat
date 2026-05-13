namespace ClickNEat.Core.Models;

public class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public List<OrderItem> Items { get; set; } = [];
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public bool PaidWithPoints { get; set; } = false;
    public int? UserId { get; set; }
    public string OrderType { get; set; } = "Pickup"; // "Pickup" | "Delivery"
    public string DeliveryAddress { get; set; } = "";
    public string DeliveryNote { get; set; } = "";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public decimal Total => Items.Sum(i => i.UnitPrice * i.Quantity);
}

public class OrderItem
{
    public int Id { get; set; }
    public int MenuItemId { get; set; }
    public string MenuItemName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}

public enum OrderStatus
{
    Pending,
    Confirmed,
    Preparing,
    Ready,
    Delivered,
    Cancelled
}
