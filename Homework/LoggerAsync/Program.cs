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
        .AddTransient<IFileService, FileService>()
        .AddTransient<LogBackupEventHandler, LogBackupEventHandler>()
        .AddTransient<Startup>();
}

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appSettings.json")
    .Build();
    
var serviceCollection = new ServiceCollection();
ConfigureService(serviceCollection, configuration);
var provider = serviceCollection.BuildServiceProvider();

var app = provider.GetService<Startup>();
app!.Start();