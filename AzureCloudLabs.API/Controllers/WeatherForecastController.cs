using AzureCloudLabs.API.Application.Interfaces;
using AzureCloudLabs.API.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace AzureCloudLabs.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(IWeatherForecastService service) : ControllerBase
{
    private readonly IWeatherForecastService service = service;

    [HttpGet(Name = "WeatherForecasts")]
    [OutputCache(Duration = 10)]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await service.GetAll();
    }


    [HttpPost(Name = "WeatherForecast")]
    public async Task<int> Add(WeatherForecast data)
    {
        return await service.Add(data);
    }
}
