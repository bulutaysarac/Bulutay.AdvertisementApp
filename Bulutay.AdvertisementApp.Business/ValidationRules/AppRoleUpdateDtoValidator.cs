using Bulutay.AdvertisementApp.Dtos;
using FluentValidation;

namespace Bulutay.AdvertisementApp.Business.ValidationRules
{
    public class AppRoleUpdateDtoValidator : AbstractValidator<AppRoleUpdateDto>
    {
        public AppRoleUpdateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}
