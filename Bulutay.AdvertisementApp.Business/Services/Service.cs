using AutoMapper;
using Bulutay.AdvertisementApp.Business.Extensions;
using Bulutay.AdvertisementApp.Business.Interfaces;
using Bulutay.AdvertisementApp.Common;
using Bulutay.AdvertisementApp.Common.Enums;
using Bulutay.AdvertisementApp.DataAccess.UnitOfWork;
using Bulutay.AdvertisementApp.Dtos.Interfaces;
using Bulutay.AdvertisementApp.Entities.Concrete;
using FluentValidation;

namespace Bulutay.AdvertisementApp.Business.Services
{
    public class Service<CreateDto, UpdateDto, ListDto, T> : IService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : class, IDto, new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IDto, new()
        where T : BaseEntity
    {
        private readonly IMapper _mapper;
        private readonly IValidator<CreateDto> _createDtoValidator;
        private readonly IValidator<UpdateDto> _updateDtoValidator;
        private readonly IUow _uow;

        public Service(IMapper mapper, IValidator<CreateDto> createDtoValidator, IValidator<UpdateDto> updateDtoValidator, IUow uow)
        {
            _mapper = mapper;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
            _uow = uow;
        }

        public async Task<IResponse<CreateDto>> CreateAsync(CreateDto dto)
        {
            var result = _createDtoValidator.Validate(dto);
            if(result.IsValid)
            {
                var entity = _mapper.Map<T>(dto);
                await _uow.GetRepository<T>().CreateAsync(entity);
                await _uow.SaveChangesAsync();
                return new Response<CreateDto>(ResponseType.Success, dto);
            }
            return new Response<CreateDto>(dto, result.ConvertToCustomValidationError());
        }

        public async Task<IResponse<List<ListDto>>> GetAllAsync()
        {
            var data = await _uow.GetRepository<T>().GetAllAsync();
            var dto = _mapper.Map<List<ListDto>>(data);
            return new Response<List<ListDto>>(ResponseType.Success, dto);
        }

        public async Task<IResponse<IDto>> GetByIdAsync<IDto>(int id)
        {
            var entity = await _uow.GetRepository<T>().GetByFilterAsync(x => x.Id == id);
            if(entity == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"Entity not found with id {id}");
            }
            var dto = _mapper.Map<IDto>(entity);
            return new Response<IDto>(ResponseType.Success, dto);
        }

        public async Task<IResponse> RemoveAsync(int id)
        {
            var entity = await _uow.GetRepository<T>().FindAsync(id);
            if(entity == null)
            {
                return new Response(ResponseType.NotFound, $"Entity not found with id {id}");
            }
            _uow.GetRepository<T>().Remove(entity);
            await _uow.SaveChangesAsync();
            return new Response(ResponseType.Success);
        }

        public async Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if(result.IsValid)
            {
                var unchangedEntity = await _uow.GetRepository<T>().FindAsync(dto.Id);
                if (unchangedEntity == null)
                {
                    return new Response<UpdateDto>(ResponseType.NotFound, $"Entity not found with id {dto.Id}");
                }
                var entity = _mapper.Map<T>(dto);
                _uow.GetRepository<T>().Update(entity, unchangedEntity);
                await _uow.SaveChangesAsync();
                return new Response<UpdateDto>(ResponseType.Success, dto);
            }
            return new Response<UpdateDto>(dto, result.ConvertToCustomValidationError());
        }
    }
}
