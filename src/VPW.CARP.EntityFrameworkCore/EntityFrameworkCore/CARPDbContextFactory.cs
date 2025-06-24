using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace VPW.CARP.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class CARPDbContextFactory : IDesignTimeDbContextFactory<CARPDbContext>
{
    public CARPDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        
        CARPEfCoreEntityExtensionMappings.Configure();

        var builder = new DbContextOptionsBuilder<CARPDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));
        
        return new CARPDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../VPW.CARP.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
