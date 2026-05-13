using ClickNEat.Core.Common;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ClickNEat.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseApiController : ControllerBase
{
    protected int CurrentUserId =>
        int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    protected IActionResult FromResult<T>(ServiceResult<T> result)
    {
        if (result.IsSuccess) return Ok(result.Value);
        return StatusCode(result.StatusCode, result.Error);
    }
}
