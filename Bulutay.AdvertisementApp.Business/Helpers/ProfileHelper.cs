using AutoMapper;
using Bulutay.AdvertisementApp.Business.Mappings.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Bulutay.AdvertisementApp.Business.Helpers
{
    public static class ProfileHelper
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>()
            {
                new ProvidedServiceProfile(),
                new AdvertisementProfile(),
                new AppUserProfile(),
                new AppRoleProfile(),
                new GenderProfile(),
                new AdvertisementAppUserProfile(),
                new AdvertisementAppUserStatusProfile(),
                new MilitaryStatusProfile()
            };
        }
    }
}
