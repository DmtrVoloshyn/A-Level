using AppWithDatabase;
using AppWithDatabase.Data;
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