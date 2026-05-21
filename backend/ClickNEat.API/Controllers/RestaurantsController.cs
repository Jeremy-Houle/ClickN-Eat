using ClickNEat.Core.DTOs;
using ClickNEat.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, UpdateRestaurantDto dto) =>
        FromResult(await restaurants.UpdateAsync(id, dto));
}
