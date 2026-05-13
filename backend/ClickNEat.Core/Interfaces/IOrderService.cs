using ClickNEat.Core.Common;
using ClickNEat.Core.DTOs;
using ClickNEat.Core.Models;

namespace ClickNEat.Core.Interfaces;

public interface IOrderService
{
    Task<PagedResult<Order>> GetMyAsync(int userId, int page, int pageSize);
    Task<PagedResult<Order>> GetAllAsync(int page, int pageSize);
    Task<ServiceResult<Order>> GetByIdAsync(int id, int userId, bool isAdmin);
    Task<ServiceResult<CreateOrderResultDto>> CreateAsync(CreateOrderDto dto, int userId);
    Task<ServiceResult<Order>> UpdateStatusAsync(int id, string status);
}
