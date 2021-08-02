using Intuition.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intuition.Infrastructures.EntityConfigurations
{
    class AppRoleEntityTypeConfiguration
    : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> config)
        {
            config.ToTable("AppRoles", IdentityContext.DEFAULT_SCHEME);

            config
                .Property(p => p.Name)
                .HasMaxLength(50);

            config.Property(p => p.NormalizedName)
                .HasMaxLength(50);

            config.Property(p => p.ConcurrencyStamp)
                .HasMaxLength(200);
        }
    }
}
