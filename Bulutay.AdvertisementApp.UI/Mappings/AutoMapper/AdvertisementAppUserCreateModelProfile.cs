using AutoMapper;
using Bulutay.AdvertisementApp.Dtos;
using Bulutay.AdvertisementApp.UI.Models;

namespace Bulutay.AdvertisementApp.UI.Mappings.AutoMapper
{
    public class AdvertisementAppUserCreateModelProfile : Profile
    {
        public AdvertisementAppUserCreateModelProfile()
        {
            CreateMap<AdvertisementAppUserCreateDto, AdvertisementAppUserCreateModel>().ReverseMap();
        }
    }
}
