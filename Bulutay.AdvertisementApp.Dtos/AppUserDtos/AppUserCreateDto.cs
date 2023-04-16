using Bulutay.AdvertisementApp.Dtos.Interfaces;

namespace Bulutay.AdvertisementApp.Dtos
{
    public class AppUserCreateDto : IDto
    {
        public string? Firstname { get; set; }
        public string? Surname { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int GenderId { get; set; }
    }
}