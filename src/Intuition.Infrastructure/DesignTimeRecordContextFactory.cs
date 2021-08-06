using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Intuition.Infrastructures
{
    public class DesignTimeRecordContextFactory : IDesignTimeDbContextFactory<RecordContext>
    {
        public RecordContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<RecordContext>();
            var connectionString = configuration.GetConnectionString("MobilPayDbPostgreSql");
            builder.UseNpgsql(connectionString);

            return new RecordContext(builder.Options);
        }
    }
}
