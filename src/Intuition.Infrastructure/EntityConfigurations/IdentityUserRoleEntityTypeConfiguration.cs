using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Intuition.Infrastructures.EntityConfigurations
{
    class IdentityUserRoleEntityTypeConfiguration
    : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> config)
        {
            config.ToTable("AppUserRoles", IdentityContext.DEFAULT_SCHEME);
        }
    }
}
