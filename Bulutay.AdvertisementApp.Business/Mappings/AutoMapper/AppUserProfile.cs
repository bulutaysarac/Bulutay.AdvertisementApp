using AutoMapper;
using Bulutay.AdvertisementApp.Dtos;
using Bulutay.AdvertisementApp.Entities.Concrete;

namespace Bulutay.AdvertisementApp.Business.Mappings.AutoMapper
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, AppUserListDto>().ReverseMap();
            CreateMap<AppUser, AppUserCreateDto>().ReverseMap();
            CreateMap<AppUser, AppUserUpdateDto>().ReverseMap();
            CreateMap<AppUserSignInDto, AppUserListDto>().ReverseMap();
        }
    }
}
