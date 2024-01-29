using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Delivery;
using Delivery.Config;
using Delivery.Services;
using Delivery.Services.Abstractions;
using Delivery.Repositories.Abstractions;

void ConfigurationService(ServiceCollection serviceCollection, IConfiguration configuration)
{
    serviceCollection.AddOptions<LogOption>().Bind(configuration.GetSection("Log"));

    serviceCollection
        .AddSingleton<ILoggerService, LoggerService>()
        .AddTransient<IVehicleRepository, IVehicleRepository>()
        .AddTransient<App>();
};

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("config.json")
    .Build();


var serviceCollection = new ServiceCollection();
ConfigurationService(serviceCollection, configuration);
var provider = serviceCollection.BuildServiceProvider();

var app = provider.GetService<App>();