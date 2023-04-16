using Bulutay.AdvertisementApp.Dtos.Interfaces;

namespace Bulutay.AdvertisementApp.Dtos
{
    public class AppRoleUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
    }
}
