using AutoMapper;
using Bulutay.AdvertisementApp.Business.Extensions;
using Bulutay.AdvertisementApp.Business.Interfaces;
using Bulutay.AdvertisementApp.Common;
using Bulutay.AdvertisementApp.Common.Enums;
using Bulutay.AdvertisementApp.DataAccess.UnitOfWork;
using Bulutay.AdvertisementApp.Dtos;
using Bulutay.AdvertisementApp.Entities.Concrete;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Bulutay.AdvertisementApp.Business.Services
{
    public class AdvertisementAppUserService : IAdvertisementAppUserService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<AdvertisementAppUserCreateDto> _createDtoValidator;

        public AdvertisementAppUserService(IUow uow, IMapper mapper, IValidator<AdvertisementAppUserCreateDto> createDtoValidator)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
        }

        public async Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var control = await _uow.GetRepository<AdvertisementAppUser>().GetByFilterAsync(x => x.AppUserId == dto.AppUserId && x.AdvertisementId == dto.AdvertisementId);
                if (control == null)
                {
                    var createdAdvertisementAppUser = _mapper.Map<AdvertisementAppUser>(dto);
                    await _uow.GetRepository<AdvertisementAppUser>().CreateAsync(createdAdvertisementAppUser);
                    await _uow.SaveChangesAsync();
                    return new Response<AdvertisementAppUserCreateDto>(ResponseType.Success, dto);
                }
                List<CustomValidationError> conflictError = new List<CustomValidationError>()
                {
                    new CustomValidationError()
                    {
                        ErrorMessage = "You have already applied to this advertisement.",
                        PropertyName = ""
                    }
                };
                return new Response<AdvertisementAppUserCreateDto>(dto, conflictError);
            }
            return new Response<AdvertisementAppUserCreateDto>(dto, result.ConvertToCustomValidationError());
        }

        public async Task<List<AdvertisementAppUserListDto>> GetList(AdvertisementAppUserStatusType type)
        {
            var query = _uow.GetRepository<AdvertisementAppUser>().GetQuery();

            var list = await query.Include(x => x.Advertisement)
                .Include(x => x.AdvertisementAppUserStatus)
                .Include(x => x.MilitaryStatus)
                .Include(x => x.AppUser)
                .ThenInclude(x => x.Gender)
                .Where(x => x.AdvertisementAppUserStatusId == (int)type).ToListAsync();

            return _mapper.Map<List<AdvertisementAppUserListDto>>(list);
        }

        public async Task SetStatusAsync(int advertisementAppUserId, AdvertisementAppUserStatusType type)
        {
            var unchanged = await _uow.GetRepository<AdvertisementAppUser>().FindAsync(advertisementAppUserId);
            var changed = await _uow.GetRepository<AdvertisementAppUser>().GetByFilterAsync(x => x.Id == advertisementAppUserId);
            changed.Id = advertisementAppUserId;
            changed.AdvertisementAppUserStatusId = (int)type;
            _uow.GetRepository<AdvertisementAppUser>().Update(changed, unchanged);
            await _uow.SaveChangesAsync();
        }
    }
}
