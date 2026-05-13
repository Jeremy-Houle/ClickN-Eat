using ClickNEat.Core.Common;
using ClickNEat.Core.DTOs;
using ClickNEat.Core.Models;

namespace ClickNEat.Core.Interfaces;

public interface IMenuItemService
{
    Task<List<MenuItem>> GetAllAsync(int? restaurantId, string? category, bool includeAll);
    Task<MenuItem?> GetByIdAsync(int id);
    Task<List<string>> GetCategoriesAsync(int? restaurantId, bool includeAll);
    Task<MenuItem> CreateAsync(CreateMenuItemDto dto);
    Task<ServiceResult<bool>> UpdateAsync(int id, UpdateMenuItemDto dto);
    Task<ServiceResult<bool>> DeleteAsync(int id);
}
