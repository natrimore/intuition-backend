using Intuition.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intuition.Infrastructures.EntityConfigurations
{
    class UserStatusEntityTypeConfiguration
      : IEntityTypeConfiguration<UserStatus>
    {
        public void Configure(EntityTypeBuilder<UserStatus> config)
        {
            config.ToTable(nameof(IdentityContext.UserStatuses), IdentityContext.DEFAULT_SCHEME);

            config.HasKey(p => new
            {
                p.Id
            });

            config
                .Property(w => w.Name)
                .IsRequired(true)
                .HasMaxLength(30);

            config
                .Property(w => w.DisplayName)
                .IsRequired(true)
                .HasMaxLength(50);

            config
                .Property(w => w.Description)
                .HasMaxLength(150)
                .IsRequired(true);

        }
    }
}
