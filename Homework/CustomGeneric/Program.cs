using CustomGeneric;
using Microsoft.Extensions.DependencyInjection;

void ConfigureService(ServiceCollection serviceCollection)
{
    serviceCollection
        .AddTransient<Startup>();
}

ServiceCollection services = new ServiceCollection();

ConfigureService(services);

var provider = services.BuildServiceProvider();

var app = provider.GetService<Startup>();
app!.Start();