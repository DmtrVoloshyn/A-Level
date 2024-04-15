using AppWithDatabase;
using AppWithDatabase.Data;
using AppWithDatabase.Data.Entities;
using AppWithDatabase.Data.Models;
using AppWithDatabase.Data.Repositories;
using AppWithDatabase.Services;
using AppWithDatabase.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

void ConfigureService(ServiceCollection serviceCollection, IConfiguration configuration)
{
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    serviceCollection.AddDbContext<AppDbContext>(opts => opts.UseSqlServer(connectionString));

    serviceCollection
        .AddLogging(configure => configure.AddConsole())
        .AddTransient<IRepository<BreedEntity>, BreedsRepository>()
        .AddTransient<IRepository<CategoryEntity>, CategoriesRepository>()
        .AddTransient<IRepository<LocationEntity>, LocationsRepository>()
        .AddTransient<IRepository<PetEntity>, PetsRepository>()
        .AddTransient<IService<Category>, CategoryService>()
        .AddTransient<IService<Breed>, BreedService>()
        .AddTransient<IService<Location>, LocationService>()
        .AddTransient<IService<Pet>, PetService>()
        .AddTransient<App>();
}

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("config.json")
    .Build();

var serviceCollection = new ServiceCollection();
ConfigureService(serviceCollection, configuration);
var provider = serviceCollection.BuildServiceProvider();

var migrationSection = configuration.GetSection("Migration");
var isNeedMigration = migrationSection.GetSection("IsNeedMigration");

if (bool.Parse(isNeedMigration.Value))
{
    var dbContext = provider.GetService<AppDbContext>();
    await dbContext!.Database.MigrateAsync();
}

var app = provider.GetService<App>();
await app!.Start();