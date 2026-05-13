namespace ClickNEat.Core.DTOs;

public record AdminStatsDto(
    int TodayOrderCount,
    decimal TodayRevenue,
    int TotalOrderCount,
    decimal TotalRevenue,
    int PendingCount,
    string TopItem,
    int TotalUsers
);

public record ToggleUserResultDto(int Id, bool IsActive);
