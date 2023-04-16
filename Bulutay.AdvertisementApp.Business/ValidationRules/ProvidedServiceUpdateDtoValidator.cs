using Bulutay.AdvertisementApp.Dtos;
using FluentValidation;

namespace Bulutay.AdvertisementApp.Business.ValidationRules
{
    public class ProvidedServiceUpdateDtoValidator: AbstractValidator<ProvidedServiceUpdateDto>
    {
        public ProvidedServiceUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.ImagePath).NotEmpty();
        }
    }
}
