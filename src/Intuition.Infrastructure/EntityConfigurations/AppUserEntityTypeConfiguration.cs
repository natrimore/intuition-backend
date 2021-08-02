using Intuition.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intuition.Infrastructures.EntityConfigurations
{
    class AppUserEntityTypeConfiguration
     : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> appUserConfiguration)
        {
            appUserConfiguration.ToTable(nameof(IdentityContext.AppUsers), IdentityContext.DEFAULT_SCHEME);

            appUserConfiguration.HasKey(p => new
            {
                p.Id
            });

            appUserConfiguration.HasIndex(p => new
            {
                p.UserName
            }).IsUnique(true);

            appUserConfiguration.HasIndex(p => new
            {
                p.Email
            }).IsUnique(true);

            appUserConfiguration.HasIndex(p => new
            {
                p.PhoneNumber
            }).IsUnique(true);

            appUserConfiguration.Property(u => u.UserName)
              .HasMaxLength(50);

            appUserConfiguration
                .Property(u => u.NormalizedUserName)
                .HasMaxLength(100);

            appUserConfiguration
                .Property(u => u.PhoneNumber)
                .HasMaxLength(50);

            appUserConfiguration
                .Property(u => u.ReservedPhoneNumber)
                .HasMaxLength(50);

            appUserConfiguration
                .Property(u => u.Email)
                .HasMaxLength(100);

            appUserConfiguration
                .Property(u => u.NormalizedEmail)
                .HasMaxLength(100);

            appUserConfiguration
                .HasOne(w => w.UserStatus)
                .WithMany()
                .HasForeignKey(w => w.StatusId);

            //appUserConfiguration
            //    .Property(u => u.IP)
            //    .HasMaxLength(15);

            //appUserConfiguration
            //    .Property(u => u.MissedCheckIP)
            //    .HasMaxLength(15);

            //appUserConfiguration
            //    .Property(u => u.IPAddressConfirmation);

            //appUserConfiguration
            //    .HasOne(u => u.UserProfile)
            //    .WithOne(p => p.AppUser)
            //    .HasForeignKey<UserProfile>(d => d.Id);

            //appUserConfiguration
            //    .HasOne(u => u.UserSetting)
            //    .WithOne(p => p.AppUser)
            //    .HasForeignKey<UserSetting>(d => d.Id);
        }
    }
}
