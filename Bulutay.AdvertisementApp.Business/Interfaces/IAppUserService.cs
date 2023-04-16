using Bulutay.AdvertisementApp.Common;
using Bulutay.AdvertisementApp.Dtos;
using Bulutay.AdvertisementApp.Entities.Concrete;

namespace Bulutay.AdvertisementApp.Business.Interfaces
{
    public interface IAppUserService : IService<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>
    {
        Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto, int roleId);
        Task<IResponse<AppUserListDto>> CheckUser(AppUserSignInDto dto);
        Task<IResponse<List<AppRoleListDto>>> GetRolesByUserIdAsync(int userId);
    }
}
