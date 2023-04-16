using Bulutay.AdvertisementApp.Dtos.Interfaces;

namespace Bulutay.AdvertisementApp.Dtos
{
    public class AppRoleListDto : IDto
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
    }
}
