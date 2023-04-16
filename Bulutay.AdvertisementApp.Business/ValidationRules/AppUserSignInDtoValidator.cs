using Bulutay.AdvertisementApp.Dtos;
using FluentValidation;

namespace Bulutay.AdvertisementApp.Business.ValidationRules
{
    public class AppUserSignInDtoValidator : AbstractValidator<AppUserSignInDto>
    {
        public AppUserSignInDtoValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
