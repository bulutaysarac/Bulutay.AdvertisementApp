using AutoMapper;
using Bulutay.AdvertisementApp.Dtos;
using Bulutay.AdvertisementApp.UI.Models;

namespace Bulutay.AdvertisementApp.UI.Mappings.AutoMapper
{
    public class AppUserCreateModelProfile : Profile
    {
        public AppUserCreateModelProfile()
        {
            CreateMap<AppUserCreateModel, AppUserCreateDto>().ReverseMap();
        }
    }
}
