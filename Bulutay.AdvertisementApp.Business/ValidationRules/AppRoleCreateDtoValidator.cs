using Bulutay.AdvertisementApp.Dtos;
using FluentValidation;

namespace Bulutay.AdvertisementApp.Business.ValidationRules
{
    public class AppRoleCreateDtoValidator : AbstractValidator<AppRoleCreateDto>
    {
        public AppRoleCreateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}
