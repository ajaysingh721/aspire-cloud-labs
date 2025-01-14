using AzureCloudLabs.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AzureCloudLabs.API.Infrastructure.Configurations
{
    public class WeatherForecastConfiguration : IEntityTypeConfiguration<WeatherForecast>
    {
        public void Configure(EntityTypeBuilder<WeatherForecast> builder)
        {
            builder.HasNoDiscriminator()
             .ToTable("WeatherForecast")
             .HasKey(x => x.Id);
        }
    }
}
