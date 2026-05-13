using ClickNEat.Core.Common;
using ClickNEat.Core.DTOs;

namespace ClickNEat.Core.Interfaces;

public interface IUserService
{
    Task<ServiceResult<ProfileUpdateResultDto>> UpdateProfileAsync(int userId, UpdateProfileDto dto);
    Task<ServiceResult<bool>> UpdatePasswordAsync(int userId, UpdatePasswordDto dto);
}
