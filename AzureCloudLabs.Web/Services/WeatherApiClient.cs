using System.Net.Http.Json;
using AzureCloudLabs.Web.Models;

namespace AzureCloudLabs.Web.Services
{
    public class WeatherServiceClient(HttpClient httpClient)
    {
        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<WeatherForecast>>("weatherforecast");
            return result ?? new List<WeatherForecast>();
        }
    }
}
