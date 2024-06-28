using Basket.Host.Converters;
using Basket.Host.Dtos;
using Basket.Host.Models;
using Basket.Host.Services.Abstractions;
using Infrastructure.Exceptions;
using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Infrastructure.RabbitMq.Abstractions;
using Infrastructure.RabbitMq.Messages.BasketMessages;

namespace Basket.Host.Controllers;

[AllowAnonymous]
public class BasketBffController : BaseController
{
    private readonly ILogger<BasketBffController> _logger;
    private readonly IBasketService _basketService;
    private readonly IEventPublisher<OrderStartedIntegrationEvent> _eventPublisher;
    private readonly IEventHandler<OrderStartedIntegrationEvent> _eventHandler;

    public BasketBffController(
        ILogger<BasketBffController> logger,
        IBasketService basketService,
        IEventPublisher<OrderStartedIntegrationEvent> eventPublisher, 
        IEventHandler<OrderStartedIntegrationEvent> eventHandler)
    {
        _logger = logger;
        _basketService = basketService;
        _eventPublisher = eventPublisher;
        _eventHandler = eventHandler;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponseDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> AddItems([FromBody] CustomerBasket newBasket)
    {
        newBasket.BuyerId ??= Guid.NewGuid().ToString();
        
        if (!TryValidateModel(newBasket))
        {
            return BadRequest(new WebApiErrorResponse((int)HttpStatusCode.BadRequest, null, ModelState.ToString()));
        }

        await _basketService.AddOrUpdateBasket(newBasket, newBasket.BuyerId);
        
        return Ok(new AddItemResponseDto {BasketId = newBasket.BuyerId});
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetItemsResponseDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetItems([FromRoute] Guid id)
    {
        CustomerBasket customerBasket;
        try
        {
            customerBasket = await _basketService.GetBasket(id.ToString());
        }
        catch (BusinessException e)
        {
            _logger.Log(LogLevel.Error, e.Message);
            return NotFound(new WebApiErrorResponse((int)HttpStatusCode.NotFound, null, e.Message));
        }

        return Ok(customerBasket.ToDto());
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteBasket([FromRoute] Guid id)
    {
        bool isDeleted;

        try
        {
            isDeleted = await _basketService.DeleteBasket(id.ToString());
        }
        catch (BusinessException e)
        {
            _logger.Log(LogLevel.Error, e.Message);
            return NotFound(new WebApiErrorResponse((int)HttpStatusCode.NotFound, null, e.Message));
        }

        return Ok(isDeleted);
    }
    
    [HttpPost("{basketId}")]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> CreateOrder([FromRoute] Guid basketId, [FromBody] CreateOrderRequestDto requestDto)
    {
        CustomerBasket customerBasket;
        try
        {
            customerBasket = await _basketService.GetBasket(basketId.ToString());
        }
        catch (BusinessException e)
        {
            _logger.Log(LogLevel.Error, e.Message);
            return NotFound(new WebApiErrorResponse((int)HttpStatusCode.NotFound, null, e.Message));
        }

        var order = await _basketService.CreateOrder(customerBasket, requestDto);
        
        return Ok(order);
    }

    //TEST PRODUSING
    [HttpPost]
    public async Task<IActionResult> CreateMess()
    {
        var message = "huy";
        //using (_eventPublisher.PublishAsync(new OrderStartedIntegrationEvent(Guid.NewGuid(),message)))
            return Ok($" [x] Sent {message}");
    }

    //TEST CONSUMING
    [HttpPost]
    public async Task<IActionResult> Consume()
    {
        var message = await _eventHandler.Consume();

        return Ok($"[x] Received {message}");
    }
}
