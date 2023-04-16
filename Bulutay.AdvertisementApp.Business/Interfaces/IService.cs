using Bulutay.AdvertisementApp.Common;
using Bulutay.AdvertisementApp.Dtos.Interfaces;
using Bulutay.AdvertisementApp.Entities.Concrete;

namespace Bulutay.AdvertisementApp.Business.Interfaces
{
    public interface IService<CreateDto, UpdateDto, ListDto, T> 
        where CreateDto : class, IDto, new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IDto, new()
        where T : BaseEntity
    {
        Task<IResponse<CreateDto>> CreateAsync(CreateDto dto);
        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto);
        Task<IResponse<IDto>> GetByIdAsync<IDto>(int id);
        Task<IResponse> RemoveAsync(int id);
        Task<IResponse<List<ListDto>>> GetAllAsync();
    }
}
