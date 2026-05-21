using ClickNEat.Core.Common;
using ClickNEat.Core.DTOs;
using ClickNEat.Core.Models;

namespace ClickNEat.Core.Interfaces;

public interface IRestaurantService
{
    Task<List<Restaurant>> GetAllAsync();
    Task<Restaurant?> GetByIdAsync(int id);
    Task<ServiceResult<Restaurant>> UpdateAsync(int id, UpdateRestaurantDto dto);
}
