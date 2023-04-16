using Bulutay.AdvertisementApp.Dtos;

namespace Bulutay.AdvertisementApp.UI.Models
{
    public class AppUserCreateModel
    {
        public string? Firstname { get; set; }
        public string? Surname { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int GenderId { get; set; }
        public List<GenderListDto>? Genders { get; set; }
    }
}
