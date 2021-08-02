using Intuition.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intuition.Infrastructures.EntityConfigurations
{
    class UserProfileEntityTypeConfiguration
        : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> config)
        {
            config.ToTable(nameof(IdentityContext.UserProfiles), IdentityContext.DEFAULT_SCHEME);

            config
                .HasKey(p => new
                {
                    p.UserId
                });

            config
                .Property(w => w.FirstName)
                .HasMaxLength(50)
                .IsRequired(false);

            config
               .Property(w => w.LastName)
               .HasMaxLength(50)
               .IsRequired(false);

            config
              .Property(w => w.LogoUrl)
              .HasMaxLength(150)
              .IsRequired(false);

            config
              .Property(w => w.BirthDate)
              .IsRequired(false);

            config
                .HasOne(w => w.Gender)
                .WithMany()
                .HasForeignKey(w => w.GenderId)
                .IsRequired(false);

            config
                .HasOne(w => w.AppUser)
                .WithOne(w => w.UserProfile)
                .HasForeignKey<UserProfile>(w => w.UserId)
                .IsRequired(true);
        }
    }
}
