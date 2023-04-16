using AutoMapper;
using Bulutay.AdvertisementApp.Business.Interfaces;
using Bulutay.AdvertisementApp.DataAccess.UnitOfWork;
using Bulutay.AdvertisementApp.Dtos;
using Bulutay.AdvertisementApp.Entities.Concrete;
using FluentValidation;

namespace Bulutay.AdvertisementApp.Business.Services
{
    public class ProvidedServiceService : Service<ProvidedServiceCreateDto, ProvidedServiceUpdateDto, ProvidedServiceListDto, ProvidedService>, IProvidedServiceService
    {
        public ProvidedServiceService(IMapper mapper, IValidator<ProvidedServiceCreateDto> createDtoValidator, IValidator<ProvidedServiceUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            
        }
    }
}
