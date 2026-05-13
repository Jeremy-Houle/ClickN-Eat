using ClickNEat.Core.Common;
using ClickNEat.Core.DTOs;

namespace ClickNEat.Core.Interfaces;

public interface IAuthService
{
    Task<ServiceResult<AuthResponseDto>> RegisterAsync(RegisterDto dto);
    Task<ServiceResult<AuthResponseDto>> LoginAsync(LoginDto dto);
}
