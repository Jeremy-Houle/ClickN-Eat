using ClickNEat.Core.Common;
using ClickNEat.Core.DTOs;

namespace ClickNEat.Core.Interfaces;

public interface IAdminService
{
    Task<AdminStatsDto> GetStatsAsync();
    Task<PagedResult<UserSummaryDto>> GetUsersAsync(int page, int pageSize);
    Task<ServiceResult<ToggleUserResultDto>> ToggleUserStatusAsync(int id, int adminId);
    Task<ServiceResult<bool>> DeleteUserAsync(int id, int adminId);
}
