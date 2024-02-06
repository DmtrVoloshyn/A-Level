using Logger;
using Logger.Config;
using Logger.Services;
using Logger.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

const string logFilePath = "/Users/dmytro.voloshyn/Projects/A-Level/Homework/Logger/Logs";

void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration, string filePath)
{
    serviceCollection.AddOptions<LoggerOption>().Bind(configuration.GetSection("Logger"));

    serviceCollection.AddSingleton<ILoggerService, LoggerService>()
        .AddTransient<Actions, Actions>()
        .AddTransient<IFileService, FileService>(provider => new FileService(filePath))
        .AddTransient<App>();
}

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath("/Users/dmytro.voloshyn/Projects/A-Level/Homework/Logger")
    .AddJsonFile("config.json")
    .Build();

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection, configuration, logFilePath);
var provider = serviceCollection.BuildServiceProvider();

var app = provider.GetService<App>();
app!.Run();