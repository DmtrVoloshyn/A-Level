using Contacts;
using Contacts.Entities;
using Contacts.Repositories;
using Contacts.Services;
using Contacts.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

void ConfigureServices(ServiceCollection service)
{
    service
        .AddTransient<ContactCollection, ContactCollection>()
        .AddTransient<IContactService, ContactService>()
        .AddTransient<IRepository<ContactEntity>, ContactRepository>()
        .AddTransient<Startup>();
}


var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection);
var provider = serviceCollection.BuildServiceProvider();

var app = provider.GetService<Startup>();
app!.Start();