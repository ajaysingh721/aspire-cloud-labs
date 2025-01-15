using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var sqlServer = builder.AddSqlServer("sql-server")
    .WithLifetime(ContainerLifetime.Persistent);

var db = sqlServer.AddDatabase("WeatherDB");

var api = builder.AddProject<Projects.AzureCloudLabs_API>("azurecloudlabs-api")
    .WithReference(cache)
    .WithReference(db)
    .WaitFor(db);

builder.AddProject<Projects.AzureCloudLabs_Web>("azurecloudlabs-web")
    .WithReference(api);

builder.Build().Run();
