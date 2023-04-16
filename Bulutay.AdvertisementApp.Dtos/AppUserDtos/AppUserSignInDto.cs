using Bulutay.AdvertisementApp.Dtos.Interfaces;

namespace Bulutay.AdvertisementApp.Dtos
{
    public class AppUserSignInDto : IDto
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
