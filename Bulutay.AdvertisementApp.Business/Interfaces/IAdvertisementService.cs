using Bulutay.AdvertisementApp.Common;
using Bulutay.AdvertisementApp.Dtos;
using Bulutay.AdvertisementApp.Entities.Concrete;

namespace Bulutay.AdvertisementApp.Business.Interfaces
{
    public interface IAdvertisementService : IService<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>
    {
        Task<IResponse<List<AdvertisementListDto>>> GetActivesAsync();
    }
}
