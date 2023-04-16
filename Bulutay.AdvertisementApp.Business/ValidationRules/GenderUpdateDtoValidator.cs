using Bulutay.AdvertisementApp.Dtos;
using FluentValidation;

namespace Bulutay.AdvertisementApp.Business.ValidationRules
{
    public class GenderUpdateDtoValidator : AbstractValidator<GenderUpdateDto>
    {
        public GenderUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}
