using Basket.Host.Dtos;
using Basket.Host.Extensions;
using Basket.Host.Models;
using Basket.Host.Repositories.Abstractions;
using Basket.Host.Services.Abstractions;
using Infrastructure.RabbitMq.Abstractions;
using Infrastructure.RabbitMq.Messages.BasketMessages;

namespace Basket.Host.Services;

public class BasketService : IBasketService
{
    private readonly ICacheRepository _cacheRepository;
    private readonly IEventPublisher<OrderStartedIntegrationEvent> _eventPublisher;


    public BasketService(ICacheRepository cacheRepository, 
        IEventPublisher<OrderStartedIntegrationEvent> eventPublisher)
    {
        _cacheRepository = cacheRepository;
        _eventPublisher = eventPublisher;
    }
    
    public async Task AddOrUpdateBasket(CustomerBasket item, string userId)
    {
        await _cacheRepository.AddOrUpdateAsync(userId, item);
    }

    public async Task<CustomerBasket> GetBasket(string userId)
    {
        return await _cacheRepository.GetAsync<CustomerBasket>(userId);
    }

    public async Task<bool> DeleteBasket(string userId)
    {
        return await _cacheRepository.DeleteBasketAsync(userId);
    }
    
    public async Task<string> CreateOrder(CustomerBasket customerBasket, CreateOrderRequestDto requestDto)
    {
        var orderId = Guid.NewGuid();
        var basketItemDtos = customerBasket.BasketItems
            .Select(item => item.ToDto())
            .ToList();
        try
        {
            await _eventPublisher.PublishAsync(
                new OrderStartedIntegrationEvent(
                    orderId,
                    customerBasket.BuyerId,
                    basketItemDtos,
                    requestDto.BuyerName,
                    requestDto.BuyerSurName,
                    requestDto.Email,
                    requestDto.FullAddress,
                    requestDto.PaymentType
                ));
        }
        finally
        {
            await _cacheRepository.DeleteBasketAsync(customerBasket.BuyerId);
        }
        
        return orderId.ToString();
    }
}