using Infrastructure.RabbitMq.Abstractions;
using Infrastructure.RabbitMq.Messages.BasketMessages;
using OrderProcessor.Enums;
using OrderProcessor.Models;
using OrderProcessor.Extensions;
using OrderProcessor.Repositories.Interfaces;

namespace OrderProcessor.RabbitMq;

public class BasketOrderIntegrationEventHandler : ICustomRabbitHandler<OrderStartedIntegrationEvent>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IBuyerRepository _buyerRepository;
    private readonly ILogger<BasketOrderIntegrationEventHandler> _logger;

    public BasketOrderIntegrationEventHandler(
        IOrderRepository orderRepository,
        IBuyerRepository buyerRepository,
        ILogger<BasketOrderIntegrationEventHandler> logger)
    {
        _orderRepository = orderRepository;
        _buyerRepository = buyerRepository;
        _logger = logger;
    }

    public async Task HandleAsync(OrderStartedIntegrationEvent @event)
    {
        if (string.IsNullOrWhiteSpace(@event.BuyerId) || @event.BasketItemDtos == null)
        {
            _logger.LogError("Invalid event data.");
            return;
        }

        try
        {
            var order = new Order(
                @event.BuyerId,
                @event.BuyerId,
                OrderStatuses.Started,
                @event.PaymentType,
                @event.TotalPrice,
                @event.BasketItemDtos.Select(i => i.ProductId).ToList());

            var buyer = new Buyer(
                @event.BuyerName,
                @event.BuyerSurName,
                @event.Email,
                @event.FullAddress);

            await _buyerRepository.Create(buyer.ToEntity());
            await _orderRepository.Create(order.ToEntity());

            _logger.LogInformation("Order and Buyer created successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing OrderStartedIntegrationEvent.");
        }
    }
}