using Bulutay.AdvertisementApp.Dtos;
using FluentValidation;

namespace Bulutay.AdvertisementApp.Business.ValidationRules
{
    public class AdvertisementCreateDtoValidator : AbstractValidator<AdvertisementCreateDto>
    {
        public AdvertisementCreateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
