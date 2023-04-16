using Bulutay.AdvertisementApp.Dtos;
using Bulutay.AdvertisementApp.Entities.Concrete;

namespace Bulutay.AdvertisementApp.Business.Interfaces
{
    public interface IGenderService : IService<GenderCreateDto, GenderUpdateDto, GenderListDto, Gender>
    {
    }
}
