using Infrastructure.RabbitMq;
using Infrastructure.RabbitMq.Abstractions;
using Infrastructure.RabbitMq.Messages;
using Infrastructure.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Infrastructure.Configurations;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterRabbitMq<TIntegrationMessage>(this IServiceCollection services,
        string queue, string exchange)
        where TIntegrationMessage : IntegrationEvent
    {
        services.AddSingleton(sp =>
        {
            var options = sp.GetRequiredService<IOptions<RabbitMqConfiguration>>().Value;

            if (options == null || string.IsNullOrEmpty(options.Host) || string.IsNullOrEmpty(options.UserName) ||
                string.IsNullOrEmpty(options.Password))
            {
                throw new ArgumentNullException("RabbitMQ configuration is not valid or null");
            }

            return new ConnectionFactory
            {
                HostName = options.Host,
                UserName = options.UserName,
                Password = options.Password
            };
        });
        
        services.AddTransient<IEventPublisher<TIntegrationMessage>>(sp =>
            new RabbitMqPublisher<TIntegrationMessage>(
                queue, exchange,
                sp.GetRequiredService<ConnectionFactory>(),
                sp.GetRequiredService<IJsonSerializer>()));
        services.AddTransient<IEventHandler<TIntegrationMessage>>(sp =>
            new RabbitMqHandler<TIntegrationMessage>(
                queue, 
                exchange,
                sp.GetRequiredService<ConnectionFactory>(),
                sp.GetRequiredService<IJsonSerializer>(),
                sp.GetRequiredService<ICustomRabbitHandler<TIntegrationMessage>>(),
                sp.GetRequiredService<ILogger<RabbitMqHandler<TIntegrationMessage>>>()));

        return services;
    }
}

public interface ICustomRabbitHandler<TIntegrationMessage> 
    where TIntegrationMessage : IntegrationEvent
{
    Task HandleAsync(TIntegrationMessage @event);
}

public class BasketTESTEventHandler : ICustomRabbitHandler<TESTIntegrationMessage>
{
    public Task HandleAsync(TESTIntegrationMessage @event)
    {
        Console.WriteLine(@event.Hello);

        return Task.CompletedTask;
    }
}