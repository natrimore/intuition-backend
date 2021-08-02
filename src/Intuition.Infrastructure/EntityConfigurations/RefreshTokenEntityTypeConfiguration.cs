using Intuition.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Intuition.Infrastructures.EntityConfigurations
{
    class RefreshTokenEntityTypeConfiguration
        : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> config)
        {
            config.ToTable(nameof(IdentityContext.RefreshTokens), IdentityContext.DEFAULT_SCHEME);

            config.HasKey(p => new
            {
                p.Id
            });

            config
                .Property(p => p.Token)
                .HasMaxLength(100)
                .IsRequired(true);

            config
                .Property(p => p.Expires)
                .IsRequired(true);

            config
                .Property(p => p.Created)
                .IsRequired(true);

            config
                .Property(p => p.CreatedByIp)
                .IsRequired(true);

            config
                .HasOne(h => h.AppUser)
                .WithMany()
                .HasForeignKey(h => h.UserId)
                .IsRequired(true);
        }
    }
}
