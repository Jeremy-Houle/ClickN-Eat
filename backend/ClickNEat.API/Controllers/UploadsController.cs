using ClickNEat.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClickNEat.API.Controllers;

[Authorize(Roles = "Admin")]
public class UploadsController(IUploadService uploadService, IConfiguration config) : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        if (file is null || file.Length == 0)
            return BadRequest("Aucun fichier reçu.");

        var baseUrl = config["App:BaseUrl"]?.TrimEnd('/') ?? $"{Request.Scheme}://{Request.Host}";

        using var stream = file.OpenReadStream();
        var result = await uploadService.UploadAsync(stream, file.FileName, file.Length, baseUrl);
        if (!result.IsSuccess) return BadRequest(result.Error);
        return Ok(new { url = result.Value });
    }
}
