using ClickNEat.Core.DTOs;
using ClickNEat.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClickNEat.API.Controllers;

[Authorize]
public class UsersController(IUserService users) : BaseApiController
{
    [HttpPut("me")]
    public async Task<IActionResult> UpdateProfile(UpdateProfileDto dto) =>
        FromResult(await users.UpdateProfileAsync(CurrentUserId, dto));

    [HttpPut("me/password")]
    public async Task<IActionResult> UpdatePassword(UpdatePasswordDto dto)
    {
        var result = await users.UpdatePasswordAsync(CurrentUserId, dto);
        if (!result.IsSuccess) return StatusCode(result.StatusCode, result.Error);
        return Ok();
    }
}
