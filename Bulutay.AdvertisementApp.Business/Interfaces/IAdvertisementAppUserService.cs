using Bulutay.AdvertisementApp.Common;
using Bulutay.AdvertisementApp.Common.Enums;
using Bulutay.AdvertisementApp.Dtos;

namespace Bulutay.AdvertisementApp.Business.Interfaces
{
    public interface IAdvertisementAppUserService
    {
        Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto);
        Task<List<AdvertisementAppUserListDto>> GetList(AdvertisementAppUserStatusType type);
        Task SetStatusAsync(int advertisementAppUserId, AdvertisementAppUserStatusType type);
    }
}
