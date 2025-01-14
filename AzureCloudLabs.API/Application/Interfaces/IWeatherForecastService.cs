using AzureCloudLabs.API.Domain.Entities;

namespace AzureCloudLabs.API.Application.Interfaces
{
    public interface IWeatherForecastService : IDataReaderService<WeatherForecast>, IDataWriterService<WeatherForecast>
    {
    }
}
