using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Intuition.Infrastructures.EntityConfigurations
{
    class IdentityUserLoginEntityTypeConfiguration
     : IEntityTypeConfiguration<IdentityUserLogin<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<Guid>> config)
        {
            config.ToTable("AppUserLogins", IdentityContext.DEFAULT_SCHEME);

            config.Property(p => p.LoginProvider)
                .HasMaxLength(50);

            config.Property(p => p.ProviderDisplayName)
                .HasMaxLength(100);

            config.Property(p => p.ProviderKey)
                .HasMaxLength(500);
        }
    }
}
