using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Intuition.Infrastructures.EntityConfigurations
{
    class IdentityUserClaimEntityTypeConfiguration
     : IEntityTypeConfiguration<IdentityUserClaim<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<Guid>> config)
        {
            config.ToTable("AppUserClaims", IdentityContext.DEFAULT_SCHEME);

            config.Property(p => p.ClaimType)
               .HasMaxLength(50);

            config.Property(p => p.ClaimValue)
                .HasMaxLength(100);
        }
    }
}
