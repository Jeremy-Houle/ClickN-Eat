using ClickNEat.Core.Models;

namespace ClickNEat.Core.Interfaces;

public interface IRestaurantService
{
    Task<List<Restaurant>> GetAllAsync();
    Task<Restaurant?> GetByIdAsync(int id);
}
