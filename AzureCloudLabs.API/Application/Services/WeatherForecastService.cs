using AzureCloudLabs.API.Application.Interfaces;
using AzureCloudLabs.API.Domain.Entities;
using AzureCloudLabs.API.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace AzureCloudLabs.API.Application.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly ApplicationDbContext context;

        public WeatherForecastService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Add(WeatherForecast entity)
        {
            context.WeatherForecasts.Add(entity);

            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<WeatherForecast>> GetAll()
        {
            return await context.WeatherForecasts.ToListAsync();
        }

    }
}
