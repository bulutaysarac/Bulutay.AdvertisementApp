using AutoMapper;
using Bulutay.AdvertisementApp.Business.Extensions;
using Bulutay.AdvertisementApp.Business.Interfaces;
using Bulutay.AdvertisementApp.Common;
using Bulutay.AdvertisementApp.Common.Enums;
using Bulutay.AdvertisementApp.DataAccess.UnitOfWork;
using Bulutay.AdvertisementApp.Dtos;
using Bulutay.AdvertisementApp.Entities.Concrete;
using FluentValidation;

namespace Bulutay.AdvertisementApp.Business.Services
{
    public class AppUserService : Service<AppUserCreateDto,  AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        private readonly IValidator<AppUserCreateDto> _createDtoValidator;
        private readonly IValidator<AppUserSignInDto> _signInDtoValidator;

        public AppUserService(IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator, IValidator<AppUserUpdateDto> updateDtoValidator, IUow uow, IValidator<AppUserSignInDto> signInDtoValidator) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _signInDtoValidator = signInDtoValidator;
        }

        public async Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto, int roleId)
        {
            var validationResult = _createDtoValidator.Validate(dto);
            if (validationResult.IsValid)
            {
                var user = _mapper.Map<AppUser>(dto);
                await _uow.GetRepository<AppUser>().CreateAsync(user);
                await _uow.GetRepository<AppUserRole>().CreateAsync(new AppUserRole()
                {
                    AppUser = user,
                    AppRoleId = roleId
                });
                await _uow.SaveChangesAsync();
                return new Response<AppUserCreateDto>(ResponseType.Success, dto);
            }
            return new Response<AppUserCreateDto>(dto, validationResult.ConvertToCustomValidationError());
        }

        public async Task<IResponse<AppUserListDto>> CheckUser(AppUserSignInDto dto)
        {
            var validationResult = _signInDtoValidator.Validate(dto);
            if(validationResult.IsValid)
            {
                var user = await _uow.GetRepository<AppUser>().GetByFilterAsync(x => x.Username == dto.Username && x.Password == dto.Password);
                if(user != null)
                {
                    var appUserDto = _mapper.Map<AppUserListDto>(dto);
                    appUserDto.Id = user.Id;
                    return new Response<AppUserListDto>(ResponseType.Success, appUserDto);
                }
                return new Response<AppUserListDto>(ResponseType.NotFound, "Username or Password is incorrect!");
            }
            return new Response<AppUserListDto>(_mapper.Map<AppUserListDto>(dto), validationResult.ConvertToCustomValidationError());
        }

        public async Task<IResponse<List<AppRoleListDto>>> GetRolesByUserIdAsync(int userId)
        {
            var roles = await _uow.GetRepository<AppRole>().GetAllAsync(x => x.AppUserRoles.Any(x => x.AppUserId == userId));
            if(roles == null)
            {
                return new Response<List<AppRoleListDto>>(ResponseType.NotFound, $"User with id:{userId} has not any roles!");
            }
            var dto = _mapper.Map<List<AppRoleListDto>>(roles);
            return new Response<List<AppRoleListDto>>(ResponseType.Success, dto);
        }
    }
}
