﻿using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Persistance;
public abstract class DesignTimeDbContextFactoryBase<TContext> :
        IDesignTimeDbContextFactory<TContext> where TContext : DbContext
{
    private const string ConnectionStringName = "KoniecToDo";
    private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";

    public TContext CreateDbContext(string[] args)
    {
        var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}KoniecToDo", Path.DirectorySeparatorChar);
        var env = Environment.GetEnvironmentVariable(AspNetCoreEnvironment);
        if(env == null)
		{
            throw new Exception($"Could not resolve environment variable: {AspNetCoreEnvironment}");
		}
        return Create(basePath, env);
    }

    protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

    private TContext Create(string basePath, string environmentName)
    {

        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.Local.json", optional: true)
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var connectionString = configuration.GetConnectionString(ConnectionStringName);

        return Create(connectionString);
    }

    private TContext Create(string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentException($"Connection string '{ConnectionStringName}' is null or empty.", nameof(connectionString));
        }

        Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");

        var optionsBuilder = new DbContextOptionsBuilder<TContext>();

        optionsBuilder.UseSqlServer(connectionString);

        return CreateNewInstance(optionsBuilder.Options);
    }
}