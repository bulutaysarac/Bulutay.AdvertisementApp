using AutoMapper;
using Bulutay.AdvertisementApp.Dtos;
using Bulutay.AdvertisementApp.Entities.Concrete;

namespace Bulutay.AdvertisementApp.Business.Mappings.AutoMapper
{
    public class GenderProfile : Profile
    {
        public GenderProfile()
        {
            CreateMap<Gender, GenderCreateDto>().ReverseMap();
            CreateMap<Gender, GenderListDto>().ReverseMap();
            CreateMap<Gender, GenderUpdateDto>().ReverseMap();
        }
    }
}
