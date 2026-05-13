using ClickNEat.Core.Common;
using ClickNEat.Core.Interfaces;

namespace ClickNEat.API.Services;

public class UploadService(IWebHostEnvironment env) : IUploadService
{
    private static readonly Dictionary<string, byte[]> MagicBytes = new()
    {
        { ".jpg",  [0xFF, 0xD8, 0xFF] },
        { ".jpeg", [0xFF, 0xD8, 0xFF] },
        { ".png",  [0x89, 0x50, 0x4E, 0x47] },
        { ".webp", [0x52, 0x49, 0x46, 0x46] },
        { ".gif",  [0x47, 0x49, 0x46, 0x38] },
    };

    public async Task<ServiceResult<string>> UploadAsync(Stream fileStream, string fileName, long fileLength, string baseUrl)
    {
        if (fileLength == 0)
            return ServiceResult<string>.Fail("errors.upload.empty");

        if (fileLength > 5 * 1024 * 1024)
            return ServiceResult<string>.Fail("errors.upload.tooLarge");

        var ext = Path.GetExtension(fileName).ToLowerInvariant();
        if (!MagicBytes.TryGetValue(ext, out var magic))
            return ServiceResult<string>.Fail("errors.upload.unsupportedFormat");

        var header = new byte[8];
        await fileStream.ReadExactlyAsync(header);

        if (!header.Take(magic.Length).SequenceEqual(magic))
            return ServiceResult<string>.Fail("errors.upload.contentMismatch");

        fileStream.Seek(0, SeekOrigin.Begin);

        var uploadsPath = Path.Combine(env.WebRootPath, "uploads");
        Directory.CreateDirectory(uploadsPath);

        var outputName = $"{Guid.NewGuid()}{ext}";
        var filePath = Path.Combine(uploadsPath, outputName);

        using var output = File.Create(filePath);
        await fileStream.CopyToAsync(output);

        return ServiceResult<string>.Ok($"{baseUrl}/uploads/{outputName}");
    }
}
