using ClickNEat.Core.Common;

namespace ClickNEat.Core.Interfaces;

public interface IUploadService
{
    Task<ServiceResult<string>> UploadAsync(Stream fileStream, string fileName, long fileLength, string baseUrl);
}
