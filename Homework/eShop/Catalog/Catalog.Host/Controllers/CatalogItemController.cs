using System.Net;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogItemController : ControllerBase
{
    private readonly ILogger<CatalogItemController> _logger;
    private readonly ICatalogItemService _service;

    public CatalogItemController(
        ILogger<CatalogItemController> logger,
        ICatalogItemService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPost("create")]
    [ProducesResponseType(typeof(AddSomeItemResponse<int?>), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> Create(CreateItemRequest request)
    {
        var result = await _service.Add(request);
        
        return Ok(new AddSomeItemResponse<int?> { Id = result });
    }

    [HttpGet("items")]
    [ProducesResponseType(typeof(PaginatedItems<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetPaginated(
        [FromQuery] string? brandTitle = null, 
        [FromQuery] string? typeTitle = null,
        [FromQuery] int pageSize = 10, 
        [FromQuery] int pageIndex = 0)
    {
        var result = await _service.Get(pageSize, pageIndex, brandTitle, typeTitle);
        
        return Ok(result);
    }
    
    [HttpGet("items/{id}")]
    [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var result = await _service.GetById(id);

        if (result is null)
        {
            return NotFound();
        }
        
        return Ok(result);
    }
    
    [HttpDelete("items/{id}")]
    [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var result = await _service.Remove(id);

        if (result is false)
        {
            return NotFound(id);
        }
        
        return Ok(result);
    }
    
    [HttpPut("update")]
    [ProducesResponseType(typeof(AddSomeItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(UpdateItemRequest request)
    {
        var result = await _service.Update(request);
        
        return Ok(new AddSomeItemResponse<int?> { Id = result.Id });
    }
}