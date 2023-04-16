using Bulutay.AdvertisementApp.Dtos;
using Bulutay.AdvertisementApp.Entities.Concrete;

namespace Bulutay.AdvertisementApp.Business.Interfaces
{
    public interface IAppRoleService : IService<AppRoleCreateDto, AppRoleUpdateDto, AppRoleListDto, AppRole>
    {

    }
}
