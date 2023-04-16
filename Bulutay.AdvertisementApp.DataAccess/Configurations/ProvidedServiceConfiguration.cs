using Bulutay.AdvertisementApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bulutay.AdvertisementApp.DataAccess.Configurations
{
    public class ProvidedServiceConfiguration : IEntityTypeConfiguration<ProvidedService>
    {
        public void Configure(EntityTypeBuilder<ProvidedService> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Title)
                .HasMaxLength(300)
                .IsRequired();

            builder
                .Property(x => x.Description)
                .HasMaxLength(300)
                .IsRequired();

            builder
                .Property(x => x.ImagePath)
                .HasMaxLength(500)
                .IsRequired();

            builder
                .Property(x => x.CreatedDate)
                .HasDefaultValueSql("getdate()")
                .IsRequired();
        }
    }
}
