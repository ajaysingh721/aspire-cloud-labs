using AzureCloudLabs.API.Application.Interfaces;
using AzureCloudLabs.API.Application.Services;
using AzureCloudLabs.API.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddDbContextFactory<ApplicationDbContext>(optionBuilder =>
{
    optionBuilder.UseSqlServer(connectionString: "sql-db");
});

builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();


var app = builder.Build();

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
