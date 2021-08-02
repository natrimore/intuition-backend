using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Intuition.Infrastructures.EntityConfigurations
{
    class IdentityRoleClaimEntityTypeConfiguration
     : IEntityTypeConfiguration<IdentityRoleClaim<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityRoleClaim<Guid>> config)
        {
            config.ToTable("AppRoleClaims", IdentityContext.DEFAULT_SCHEME);

            config.Property(p => p.ClaimType)
                .HasMaxLength(50);

            config.Property(p => p.ClaimValue)
                .HasMaxLength(100);
        }
    }
}
