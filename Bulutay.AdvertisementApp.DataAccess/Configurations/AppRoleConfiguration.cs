using Bulutay.AdvertisementApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bulutay.AdvertisementApp.DataAccess.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Definition)
                .HasMaxLength(128)
                .IsRequired();

            builder
                .HasData(new AppRole[]
                {
                    new AppRole()
                    {
                        Id = 1,
                        Definition = "Admin"
                    },
                    new AppRole()
                    {
                        Id = 2,
                        Definition = "Member"
                    }
                });
        }
    }
}
