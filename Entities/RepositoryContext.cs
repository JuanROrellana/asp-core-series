using System;
using System.IO;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Entities
{
    public class RepositoryContext:  DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { } 
        
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
    
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory().Replace("Entities", "api"))
            .AddJsonFile("appsettings.json")
            .Build();
            var builder = new DbContextOptionsBuilder<RepositoryContext>(); 
            var connectionString = configuration["mysqlconnection:connectionString"];
            builder.UseMySql(connectionString); 
            return new RepositoryContext(builder.Options); 
        } 
    }
}