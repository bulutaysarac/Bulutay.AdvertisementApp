using AutoMapper;
using Bulutay.AdvertisementApp.Business.Interfaces;
using Bulutay.AdvertisementApp.DataAccess.UnitOfWork;
using Bulutay.AdvertisementApp.Dtos;
using Bulutay.AdvertisementApp.Entities.Concrete;
using FluentValidation;

namespace Bulutay.AdvertisementApp.Business.Services
{
    public class AppRoleService : Service<AppRoleCreateDto, AppRoleUpdateDto, AppRoleListDto, AppRole>, IAppRoleService
    {
        public AppRoleService(IMapper mapper, IValidator<AppRoleCreateDto> createDtoValidator, IValidator<AppRoleUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {

        }
    }
}
