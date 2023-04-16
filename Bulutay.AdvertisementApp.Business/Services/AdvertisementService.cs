using AutoMapper;
using Bulutay.AdvertisementApp.Business.Interfaces;
using Bulutay.AdvertisementApp.Common;
using Bulutay.AdvertisementApp.Common.Enums;
using Bulutay.AdvertisementApp.DataAccess.UnitOfWork;
using Bulutay.AdvertisementApp.Dtos;
using Bulutay.AdvertisementApp.Entities.Concrete;
using FluentValidation;

namespace Bulutay.AdvertisementApp.Business.Services
{
    public class AdvertisementService : Service<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>, IAdvertisementService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;
        public AdvertisementService(IMapper mapper, IValidator<AdvertisementCreateDto> createDtoValidator, IValidator<AdvertisementUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IResponse<List<AdvertisementListDto>>> GetActivesAsync()
        {
            var data = await _uow.GetRepository<Advertisement>().GetAllAsync(x => x.Status, x => x.CreatedDate, OrderByType.DESC);
            var dto = _mapper.Map<List<AdvertisementListDto>>(data);
            return new Response<List<AdvertisementListDto>>(ResponseType.Success, dto);
        }
    }
}
