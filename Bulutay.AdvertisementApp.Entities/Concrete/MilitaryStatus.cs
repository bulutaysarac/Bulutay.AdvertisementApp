namespace Bulutay.AdvertisementApp.Entities.Concrete
{
    public class MilitaryStatus : BaseEntity
    {
        public string Definition { get; set; }
        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
