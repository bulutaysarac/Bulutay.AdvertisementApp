using Bulutay.AdvertisementApp.UI.Models;
using FluentValidation;

namespace Bulutay.AdvertisementApp.UI.ValidationRules
{
    public class AppUserCreateModelValidator : AbstractValidator<AppUserCreateModel>
    {
        public AppUserCreateModelValidator()
        {
            RuleFor(x => x.Password).NotEmpty().Equal(x => x.ConfirmPassword);
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.ConfirmPassword).NotEmpty();
            RuleFor(x => x.Firstname).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.GenderId).NotEmpty();
        }
    }
}
