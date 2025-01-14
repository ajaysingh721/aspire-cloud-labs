using System.Reflection;
using AzureCloudLabs.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AzureCloudLabs.API.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions contextOptions):base(contextOptions)
        {
            
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
