using Intuition.Domains.References;
using Intuition.Infrastructures.EntityConfigurations.Reference;
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

            builder.ApplyConfiguration(new AppTimeZoneEntityTypeConfiguration());

            builder.ApplyConfiguration(new LanguageEntityTypeConfiguration());

            builder.ApplyConfiguration(new GenderEntityTypeConfiguration());
        }

        public DbSet<Gender> Genders { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<AppTimeZone> AppTimeZones { get; set; }
    }
}
