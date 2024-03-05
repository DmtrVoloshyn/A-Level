using LoggerAsync;
using LoggerAsync.EventHandlers;
using LoggerAsync.Helpers;
using LoggerAsync.Options;
using LoggerAsync.Services;
using LoggerAsync.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

void ConfigureService(ServiceCollection services, IConfiguration configuration)
{
    services.Configure<LoggerOptions>(configuration.GetSection("Logger"));
    
    LoggerHelper.Configure(configuration.GetSection("Logger").Get<LoggerOptions>() ?? throw new InvalidOperationException());
    
    services
        .AddSingleton<ILoggerService, LoggerService>()
        .AddSingleton<IFileService, FileService>()
        .AddSingleton<LogBackupEventHandler, LogBackupEventHandler>()
        .AddSingleton<App>();
}

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appSettings.json")
    .Build();
    
var serviceCollection = new ServiceCollection();
ConfigureService(serviceCollection, configuration);
var provider = serviceCollection.BuildServiceProvider();

var app = provider.GetService<App>();
await app!.Start();