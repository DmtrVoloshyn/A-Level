using LoggerAsync;
using LoggerAsync.EventHandlers;
using LoggerAsync.Options;
using LoggerAsync.Services;
using LoggerAsync.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

void ConfigureService(ServiceCollection services, IConfiguration configuration)
{
    services.AddOptions<LoggerOptions>()
        .Bind(configuration.GetSection("Logger"));
    
    services
        .AddSingleton<ILoggerService, LoggerService>()
        .AddSingleton<IFileService, FileService>()
        .AddSingleton<LogBackupEventHandler, LogBackupEventHandler>()
        .AddSingleton<Startup>();
}

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appSettings.json")
    .Build();
    
var serviceCollection = new ServiceCollection();
ConfigureService(serviceCollection, configuration);
var provider = serviceCollection.BuildServiceProvider();

var app = provider.GetService<Startup>();
await app!.Start();