using AutoMapper;
using Bulutay.AdvertisementApp.Dtos;
using Bulutay.AdvertisementApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulutay.AdvertisementApp.Business.Mappings.AutoMapper
{
    public class ProvidedServiceProfile : Profile
    {
        public ProvidedServiceProfile()
        {
            CreateMap<ProvidedServiceCreateDto, ProvidedService>().ReverseMap();
            CreateMap<ProvidedServiceUpdateDto, ProvidedService>().ReverseMap();
            CreateMap<ProvidedServiceListDto, ProvidedService>().ReverseMap();
        }
    }
}
