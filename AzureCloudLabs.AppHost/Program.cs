using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var sqlServer = builder.AddSqlServer("sql-db")
    .AddDatabase("WeatherDB");  

var api = builder.AddProject<Projects.AzureCloudLabs_API>("azurecloudlabs-api")
    .WithReference(cache)
    .WithReference(sqlServer);

builder.AddProject<Projects.AzureCloudLabs_Web>("azurecloudlabs-web")
    .WithReference(api);

builder.Build().Run();
