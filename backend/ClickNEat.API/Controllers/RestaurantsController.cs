using ClickNEat.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClickNEat.API.Controllers;

public class RestaurantsController(IRestaurantService restaurants) : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await restaurants.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var r = await restaurants.GetByIdAsync(id);
        return r is null ? NotFound() : Ok(r);
    }
}
