using Microsoft.Extensions.DependencyInjection;
using Salad;
using Salad.Services;
using Salad.Repositories;
using Salad.Entities;

public class Program
{
    static void Main()
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        var provider = serviceCollection.BuildServiceProvider();

        var app = provider.GetService<App>();
        app!.Start();
    }

    static void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IRepository<VegetableEntity>, VegetablesRepository>()
            .AddTransient<VegetablesService, VegetablesService>()
            .AddTransient<KitchenService, KitchenService>()
            .AddTransient<App>();
    }
}