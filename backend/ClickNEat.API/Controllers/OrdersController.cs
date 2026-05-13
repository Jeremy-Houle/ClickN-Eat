using ClickNEat.Core.DTOs;
using ClickNEat.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClickNEat.API.Controllers;

[Authorize]
public class OrdersController(IOrderService orders) : BaseApiController
{
    [HttpGet("my")]
    public async Task<IActionResult> GetMy([FromQuery] int page = 1, [FromQuery] int pageSize = 20) =>
        Ok(await orders.GetMyAsync(CurrentUserId, page, pageSize));

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 50) =>
        Ok(await orders.GetAllAsync(page, pageSize));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) =>
        FromResult(await orders.GetByIdAsync(id, CurrentUserId, User.IsInRole("Admin")));

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderDto dto)
    {
        var result = await orders.CreateAsync(dto, CurrentUserId);
        if (!result.IsSuccess) return StatusCode(result.StatusCode, result.Error);
        return CreatedAtAction(nameof(GetById), new { id = result.Value!.Order.Id }, result.Value);
    }

    [HttpPatch("{id}/status")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateStatus(int id, UpdateOrderStatusDto dto) =>
        FromResult(await orders.UpdateStatusAsync(id, dto.Status));
}
