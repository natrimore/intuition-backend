using Intuition.Domains;
using Intuition.Domains.References;
using Intuition.Infrastructures.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intuition.Infrastructures
{
    public class IdentityContext : IdentityDbContext<AppUser, AppRole, Guid> 
    {
        internal const string DEFAULT_SCHEME = "Identity";
        internal const string REFERENCES_SCHEME = "Reference";


        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema(DEFAULT_SCHEME);

            builder.ApplyConfiguration(new AppUserEntityTypeConfiguration());

            builder.ApplyConfiguration(new AppRoleEntityTypeConfiguration());

            builder.ApplyConfiguration(new UserProfileEntityTypeConfiguration());

            builder.ApplyConfiguration(new UserStatusEntityTypeConfiguration());

            builder.ApplyConfiguration(new UserSettingEntityTypeConfiguration());

            builder.ApplyConfiguration(new IdentityRoleClaimEntityTypeConfiguration());

            builder.ApplyConfiguration(new IdentityUserClaimEntityTypeConfiguration());

            builder.ApplyConfiguration(new IdentityUserLoginEntityTypeConfiguration());

            builder.ApplyConfiguration(new IdentityUserRoleEntityTypeConfiguration());

            builder.ApplyConfiguration(new IdentityUserTokenEntityTypeConfiguration());

            builder.ApplyConfiguration(new RefreshTokenEntityTypeConfiguration());

            builder.ApplyConfiguration(new ErrorEntityTypeConfiguration());

            builder.Entity<Gender>().ToTable(nameof(ReferenceContext.Genders), REFERENCES_SCHEME).HasKey(w => new { w.Id });

            builder.Entity<Language>().ToTable(nameof(ReferenceContext.Languages), REFERENCES_SCHEME).HasKey(w => new { w.Id });

            builder.Entity<AppTimeZone>().ToTable(nameof(ReferenceContext.AppTimeZones), REFERENCES_SCHEME).HasKey(w => new { w.Id });
        }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<UserStatus> UserStatuses { get; set; }

        //public DbSet<SessionToUser> SessionToUsers { get; set; }

        //public DbSet<UserVerificationCode> UserVerificationCodes { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<UserSetting> UserSettings { get; set; }

        //public DbSet<LocalizedUserStatus> LocalizedUserStatuses { get; set; }

        public DbSet<Error> Errors { get; set; }

        //public DbSet<PasswordRecoveryCode> PasswordRecoveryCodes { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
