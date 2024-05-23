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
    private readonly ICatalogItemService _catalogItemService;

    public CatalogItemController(
        ILogger<CatalogItemController> logger,
        ICatalogItemService catalogItemService)
    {
        _logger = logger;
        _catalogItemService = catalogItemService;
    }

    [HttpPost("create")]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> Create(CreateProductRequest request)
    {
        var result = await _catalogItemService.Add(request.Name, 
            request.Description, 
            request.Price, 
            request.AvailableStock, 
            request.CatalogBrandId, 
            request.CatalogTypeId, 
            request.PictureFileName);
        
        return Ok(new AddItemResponse<int?> { Id = result });
    }

    [HttpGet]
    [ProducesResponseType(typeof(PaginatedItems<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetPaginated(
        [FromQuery] string? brandTitle = null, 
        [FromQuery] string? typeTitle = null,
        [FromQuery] int pageSize = 10, 
        [FromQuery] int pageIndex = 0)
    {
        var result = await _catalogItemService.Get(pageSize, pageIndex, brandTitle, typeTitle);
        
        return Ok(result);
    }
    
    [HttpGet("items/{id}")]
    [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var result = await _catalogItemService.GetById(id);

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
        var result = await _catalogItemService.DeleteItem(id);

        if (result is false)
        {
            return NotFound(id);
        }
        
        return Ok(result);
    }
    
    //FIXME
    [HttpPut("update/{id}")]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update([FromRoute] int id, CreateProductRequest request)
    {
        var result = await _catalogItemService.UpdateItem(
            id, 
            request.Name, 
            request.Description, 
            request.Price, 
            request.AvailableStock, 
            request.CatalogBrandId, 
            request.CatalogTypeId, 
            request.PictureFileName);
        
        return Ok(new AddItemResponse<int?> { Id = result });
    }
}