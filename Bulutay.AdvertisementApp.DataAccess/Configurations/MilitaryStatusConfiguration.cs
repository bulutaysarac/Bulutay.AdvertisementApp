using Bulutay.AdvertisementApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bulutay.AdvertisementApp.DataAccess.Configurations
{
    public class MilitaryStatusConfiguration : IEntityTypeConfiguration<MilitaryStatus>
    {
        public void Configure(EntityTypeBuilder<MilitaryStatus> builder)
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
