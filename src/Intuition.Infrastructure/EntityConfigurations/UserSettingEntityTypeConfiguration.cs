using Intuition.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intuition.Infrastructures.EntityConfigurations
{
    class UserSettingEntityTypeConfiguration
     : IEntityTypeConfiguration<UserSetting>
    {
        public void Configure(EntityTypeBuilder<UserSetting> config)
        {
            config.ToTable(nameof(IdentityContext.UserSettings), IdentityContext.DEFAULT_SCHEME);

            config.HasKey(p => new
            {
                p.UserId
            });

            config
                .HasOne(w => w.AppUser)
                .WithOne(w => w.UserSetting)
                .HasForeignKey<UserSetting>(w => w.UserId);


            config
                .HasOne(w => w.Language)
                .WithMany()
                .HasForeignKey(w => w.LanguageId)
                .IsRequired(true);

            config
                .Property(w => w.LanguageId)
                .HasMaxLength(3);

            config
                .HasOne(w => w.AppTimeZone)
                .WithMany()
                .HasForeignKey(w => w.AppTimeZoneId)
                .IsRequired(true);

            config
                .Property(w => w.AppTimeZoneId)
                .HasMaxLength(50);

            config
                .Property(w => w.TwoFactorAuthenticationEnabled);

            //   config
            //      .Property(w => w.PushNotificationEnabled);
        }
    }
}
