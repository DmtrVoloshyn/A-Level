using Collection;
using Collection.Services;
using Collection.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Collection.Repositories;

void ConfigureServices(ServiceCollection serviceCollection)
{
    serviceCollection
    .AddScoped<IOrderService, OrderService>()
    .AddTransient<IOrderRepository, OrderRepository>()
    .AddTransient<Startup>();
}

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection);
var provider = serviceCollection.BuildServiceProvider();

var app = provider.GetService<Startup>();
app!.Start();