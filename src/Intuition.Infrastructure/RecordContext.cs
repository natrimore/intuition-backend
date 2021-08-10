using Intuition.Domains;
using Intuition.Domains.Records;
using Intuition.Infrastructures.EntityConfigurations.Records;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intuition.Infrastructures
{
    public class RecordContext : DbContext
    {
        internal const string DEFAULT_SCHEME = "Record";
        internal const string IDENTITY_SCHEME = "Identity";

        public RecordContext(DbContextOptions<RecordContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema(DEFAULT_SCHEME);

            builder.ApplyConfiguration(new RecordEntityConfiguration());

            builder.Entity<AppUser>().ToTable(nameof(IdentityContext.AppUsers), IDENTITY_SCHEME);
        }

        public DbSet<Record> Records { get; set; }
    }
}
