using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ElectricalAppliances;
using ElectricalAppliances.Repositories;
using ElectricalAppliances.Repositories.Abstractions;
using ElectricalAppliances.Entities;
using ElectricalAppliances.Services;
using ElectricalAppliances.Options;
using ElectricalAppliances.Mappings;


void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
{
    serviceCollection.AddOptions<LogOption>().Bind(configuration.GetSection("Logger"));

    serviceCollection
    .AddSingleton<ILoggerService, LoggerService>()
    .AddTransient<IRepository<ElectronicDeviceEntity>, ElectricalDevicesRepository>()
    .AddTransient<IHouseService, HouseService>()
    .AddAutoMapper(typeof(MappingProfile))
    .AddTransient<Startup>();
}

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath("/Users/dmytro.voloshyn/Projects/A-Level/Homework/ElectricalAppliances")
    .AddJsonFile("config.json")
    .Build();

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection, configuration);
var provider = serviceCollection.BuildServiceProvider();

var app = provider.GetService<Startup>();
app!.Start();