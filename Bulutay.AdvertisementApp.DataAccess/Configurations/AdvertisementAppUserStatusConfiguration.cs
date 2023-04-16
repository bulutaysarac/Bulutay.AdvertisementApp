using Bulutay.AdvertisementApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bulutay.AdvertisementApp.DataAccess.Configurations
{
    public class AdvertisementAppUserStatusConfiguration : IEntityTypeConfiguration<AdvertisementAppUserStatus>
    {
        public void Configure(EntityTypeBuilder<AdvertisementAppUserStatus> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Definition)
                .HasMaxLength(300)
                .IsRequired();
        }
    }
}
