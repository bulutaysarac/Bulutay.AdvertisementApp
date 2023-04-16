using Bulutay.AdvertisementApp.Dtos.Interfaces;

namespace Bulutay.AdvertisementApp.Dtos
{
    public class GenderUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string? Definition { get; set; }
    }
}
