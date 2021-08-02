using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Intuition.Infrastructures.EntityConfigurations
{
    class IdentityUserTokenEntityTypeConfiguration
     : IEntityTypeConfiguration<IdentityUserToken<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<Guid>> config)
        {
            config.ToTable("AppUserTokens", IdentityContext.DEFAULT_SCHEME);

            config.Property(p => p.Name)
                .HasMaxLength(200);

            config.Property(p => p.Value)
                .HasMaxLength(1000);

            config.Property(p => p.LoginProvider)
                .HasMaxLength(50);
        }
    }
}
