using AzureCloudLabs.API.Application.Interfaces;
using AzureCloudLabs.API.Application.Services;
using AzureCloudLabs.API.Domain.Entities;
using AzureCloudLabs.API.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddSqlServerDbContext<ApplicationDbContext>("WeatherDB");
builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.AddRedisOutputCache(connectionName: "cache");

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(host =>
    {
        host.SetIsOriginAllowed(host => true);
    });
});

builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();




var app = builder.Build();

await using (var providerScope = app.Services.CreateAsyncScope())
await using (var dbContext = providerScope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
{
    await dbContext.Database.EnsureCreatedAsync();

    if (!dbContext.WeatherForecasts.Any())
    {
        await dbContext.AddAsync<WeatherForecast>(new()
        {
            Id = Guid.NewGuid(),
            Date = DateOnly.FromDateTime(DateTime.Now),
            TemperatureC = 30,
            Summary = "this is a test"
        });

        await dbContext.SaveChangesAsync();
    }
}

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseOutputCache();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
