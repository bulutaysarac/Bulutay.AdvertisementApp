using Bulutay.AdvertisementApp.Dtos.Interfaces;

namespace Bulutay.AdvertisementApp.Dtos
{
    public class MilitaryStatusListDto : IDto
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
    }
}
