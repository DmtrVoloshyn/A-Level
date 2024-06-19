using Basket.Host.Models;
using Basket.Host.Services.Interfaces;
using Infrastructure.Exceptions;
using Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;

namespace Basket.Host.Controllers;

[AllowAnonymous]
public class BasketBffController : BaseController
{
    private readonly ILogger<BasketBffController> _logger;
    private readonly IBasketService _basketService;

    public BasketBffController(
        ILogger<BasketBffController> logger,
        IBasketService basketService)
    {
        _logger = logger;
        _basketService = basketService;
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddItems(AddItemRequestDto data)
    {
        await _basketService.Add(data.Id, data.Data);
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
}