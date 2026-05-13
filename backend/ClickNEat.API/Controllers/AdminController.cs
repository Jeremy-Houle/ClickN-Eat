using ClickNEat.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClickNEat.API.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController(IAdminService admin) : BaseApiController
{
    [HttpGet("stats")]
    public async Task<IActionResult> GetStats() =>
        Ok(await admin.GetStatsAsync());

    [HttpGet("users")]
    public async Task<IActionResult> GetUsers([FromQuery] int page = 1, [FromQuery] int pageSize = 50) =>
        Ok(await admin.GetUsersAsync(page, pageSize));

    [HttpPatch("users/{id}/status")]
    public async Task<IActionResult> ToggleUserStatus(int id) =>
        FromResult(await admin.ToggleUserStatusAsync(id, CurrentUserId));

    [HttpDelete("users/{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var result = await admin.DeleteUserAsync(id, CurrentUserId);
        if (!result.IsSuccess) return StatusCode(result.StatusCode, result.Error);
        return NoContent();
    }
}
