using Bulutay.AdvertisementApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bulutay.AdvertisementApp.DataAccess.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Firstname)
                .HasMaxLength(300)
                .IsRequired();

            builder
                .Property(x => x.Surname)
                .HasMaxLength(300)
                .IsRequired();

            builder
                .Property(x => x.Username)
                .HasMaxLength(30)
                .IsRequired();

            builder
                .Property(x => x.Email)
                .HasMaxLength(30)
                .IsRequired();

            builder
                .Property(x => x.Password)
                .HasMaxLength(16)
                .IsRequired();

            builder
                .Property(x => x.PhoneNumber)
                .HasMaxLength(15)
                .IsRequired();

            builder
                .HasOne(x => x.Gender)
                .WithMany(x => x.AppUsers)
                .HasForeignKey(x => x.GenderId);
        }
    }
}
