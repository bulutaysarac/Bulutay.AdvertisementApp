namespace Bulutay.AdvertisementApp.Entities.Concrete
{
    public class Gender : BaseEntity
    {
        public string Definition { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
