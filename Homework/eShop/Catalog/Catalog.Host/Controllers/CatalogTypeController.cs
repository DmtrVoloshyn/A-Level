using System.Net;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

public class CatalogTypeController : BaseController
{
    private readonly ILogger<CatalogTypeController> _logger;
    private readonly ICatalogTypeService _service;

    public CatalogTypeController(ILogger<CatalogTypeController> logger, ICatalogTypeService service)
    {
        _logger = logger;
        _service = service;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CatalogTypeDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetTypes()
    {
        var result = await _service.Get();

        return Ok(result);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CatalogBrandDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetTypeById([FromRoute] int id)
    {
        var result = await _service.GetById(id);

        if (result is null)
        {
            return NotFound(new WebApiErrorResponse((int)HttpStatusCode.NotFound, null, null));
        }

        return Ok(result);
    }
    
    [HttpPost("create")]
    [ProducesResponseType(typeof(AddSomeItemResponse<int?>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
    public async Task<IActionResult> CreateItemType([FromBody] string itemType)
    {
        var result = await _service.Add(itemType);

        if (result is null)
        {
            return UnprocessableEntity(new WebApiErrorResponse((int)HttpStatusCode.UnprocessableEntity, null, null));
        }

        return Ok(new AddSomeItemResponse<int?> {Id = result});
    }
    
    [HttpPut("update")]
    [ProducesResponseType(typeof(AddSomeItemResponse<int?>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateTypeById(CatalogTypeDto dto)
    {
        var result = await _service.Update(dto);

        if (result is null)
        {
            return NotFound(new WebApiErrorResponse((int)HttpStatusCode.NotFound, null, null));
        }

        return Ok(result);
    }
    
    [HttpDelete("delete/{id}")]
    [ProducesResponseType(typeof(AddSomeItemResponse<int?>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteItemType([FromRoute] int id)
    {
        var result = await _service.Remove(id);

        if (result is false)
        {
            return NotFound(new WebApiErrorResponse((int)HttpStatusCode.NotFound, null, null));
        }

        return Ok(result);
    }
}