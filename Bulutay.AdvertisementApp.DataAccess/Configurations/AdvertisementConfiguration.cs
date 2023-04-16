using Bulutay.AdvertisementApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bulutay.AdvertisementApp.DataAccess.Configurations
{
    public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(x => x.Description)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(x => x.CreatedDate)
                .HasDefaultValueSql("getdate()");
        }
    }
}
