using System.Text;
using Basket.Host.Dtos;
using Basket.Host.Models;
using Basket.Host.Services.Interfaces;
using Infrastructure.Exceptions;
using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Infrastructure.RabbitMq.Abstractions;
using Infrastructure.RabbitMq.Messages;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Basket.Host.Controllers;

[AllowAnonymous]
public class BasketBffController : BaseController
{
    private readonly ILogger<BasketBffController> _logger;
    private readonly IBasketService _basketService;
    private readonly IEventPublisher<TESTIntegrationMessage> _eventPublisher;
    private readonly IEventHandler<TESTIntegrationMessage> _eventHandler;

    public BasketBffController(
        ILogger<BasketBffController> logger,
        IBasketService basketService,
        IEventPublisher<TESTIntegrationMessage> eventPublisher, 
        IEventHandler<TESTIntegrationMessage> eventHandler)
    {
        _logger = logger;
        _basketService = basketService;
        _eventPublisher = eventPublisher;
        _eventHandler = eventHandler;
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> AddItems([FromBody] BasketItem item)
    {
        if (!TryValidateModel(item))
        {
            return BadRequest(new WebApiErrorResponse((int)HttpStatusCode.BadRequest, null, ModelState.ToString()));
        }

        await _basketService.Add(item);
        return Ok();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetItemsResponseDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetItems([FromRoute] Guid id)
    {
        GetItemsResponseDto responseDto;

        try
        {
            responseDto = await _basketService.Get(id);
        }
        catch (BusinessException e)
        {
            _logger.Log(LogLevel.Error, e.Message);
            return NotFound(new WebApiErrorResponse((int)HttpStatusCode.NotFound, null, e.Message));
        }

        return Ok(responseDto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateMess()
    {
        var message = "huy";
        using (_eventPublisher.PublishAsync(new TESTIntegrationMessage{Id = Guid.NewGuid(), Hello = message}))
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
