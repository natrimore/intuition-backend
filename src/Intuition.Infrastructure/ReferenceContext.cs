using Intuition.Domains.References;
using Microsoft.EntityFrameworkCore;

namespace Intuition.Infrastructures
{
    public class ReferenceContext : DbContext
    {
        internal const string DEFAULT_SCHEME = "Reference";
        public ReferenceContext(DbContextOptions<ReferenceContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema(DEFAULT_SCHEME);

            builder.Entity<Gender>().ToTable(nameof(Genders)).HasKey(w => new { w.Id });

            builder.Entity<Language>().ToTable(nameof(Languages)).HasKey(w => new { w.Id });

            builder.Entity<AppTimeZone>().ToTable(nameof(AppTimeZones)).HasKey(w => new { w.Id });
        }

        public DbSet<Gender> Genders { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<AppTimeZone> AppTimeZones { get; set; }
    }
}
