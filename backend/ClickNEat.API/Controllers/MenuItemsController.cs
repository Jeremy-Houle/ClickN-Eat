using ClickNEat.Core.DTOs;
using ClickNEat.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClickNEat.API.Controllers;

public class MenuItemsController(IMenuItemService menuItems) : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] int? restaurantId = null,
        [FromQuery] string? category = null,
        [FromQuery] bool includeAll = false)
    {
        var effectiveIncludeAll = includeAll && User.IsInRole("Admin");
        return Ok(await menuItems.GetAllAsync(restaurantId, category, effectiveIncludeAll));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await menuItems.GetByIdAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpGet("categories")]
    public async Task<IActionResult> GetCategories(
        [FromQuery] int? restaurantId = null,
        [FromQuery] bool includeAll = false)
    {
        var effectiveIncludeAll = includeAll && User.IsInRole("Admin");
        return Ok(await menuItems.GetCategoriesAsync(restaurantId, effectiveIncludeAll));
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(CreateMenuItemDto dto)
    {
        var item = await menuItems.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id, UpdateMenuItemDto dto)
    {
        var result = await menuItems.UpdateAsync(id, dto);
        if (!result.IsSuccess) return StatusCode(result.StatusCode, result.Error);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await menuItems.DeleteAsync(id);
        if (!result.IsSuccess) return StatusCode(result.StatusCode, result.Error);
        return NoContent();
    }
}
