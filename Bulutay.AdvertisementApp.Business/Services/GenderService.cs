using AutoMapper;
using Bulutay.AdvertisementApp.Business.Interfaces;
using Bulutay.AdvertisementApp.DataAccess.UnitOfWork;
using Bulutay.AdvertisementApp.Dtos;
using Bulutay.AdvertisementApp.Entities.Concrete;
using FluentValidation;

namespace Bulutay.AdvertisementApp.Business.Services
{
    public class GenderService : Service<GenderCreateDto, GenderUpdateDto, GenderListDto, Gender>, IGenderService
    {
        public GenderService(IMapper mapper, IValidator<GenderCreateDto> createDtoValidator, IValidator<GenderUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
        }
    }
}
