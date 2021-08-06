using Intuition.Domains.Records;
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
        public RecordContext(DbContextOptions<RecordContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Record> Records { get; set; }
    }
}
