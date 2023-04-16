using Bulutay.AdvertisementApp.Dtos;
using FluentValidation;

namespace Bulutay.AdvertisementApp.Business.ValidationRules
{
    public class AppUserCreateDtoValidator : AbstractValidator<AppUserCreateDto>
    {
        public AppUserCreateDtoValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.GenderId).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Username).NotEmpty();
        }
    }
}
