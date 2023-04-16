using Bulutay.AdvertisementApp.Common.Enums;
using Bulutay.AdvertisementApp.Dtos;
using FluentValidation;

namespace Bulutay.AdvertisementApp.Business.ValidationRules
{
    public class AdvertisementAppUserCreateDtoValidator : AbstractValidator<AdvertisementAppUserCreateDto>
    {
        public AdvertisementAppUserCreateDtoValidator()
        {
            RuleFor(x => x.AdvertisementAppUserStatusId).NotEmpty();
            RuleFor(x => x.AdvertisementId).NotEmpty();
            RuleFor(x => x.AppUserId).NotEmpty();
            RuleFor(x => x.CvPath).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty().When(x => x.MilitaryStatusId == (int)MilitaryStatusType.Delayed);
        }
    }
}
