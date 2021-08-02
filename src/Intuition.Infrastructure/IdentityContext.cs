using Intuition.Domains;
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

        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
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
