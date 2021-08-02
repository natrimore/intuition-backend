﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Intuition.Infrastructures
{
    public class DesignTImeIntuitionContextFactory : IDesignTimeDbContextFactory<IdentityContext>
    {
        public IdentityContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<IdentityContext>();
            var connectionString = configuration.GetConnectionString("MobilPayDbPostgreSql");
            builder.UseNpgsql(connectionString);

            return new IdentityContext(builder.Options);
        }
    }
}
