using System.Net;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

public class CatalogBrandController : BaseController
{
    private readonly ILogger<CatalogBrandController> _logger;
    private readonly ICatalogBrandService _service;

    public CatalogBrandController(ILogger<CatalogBrandController> logger, ICatalogBrandService catalogIBrandService)
    {
        _logger = logger;
        _service = catalogIBrandService;
    }

    [HttpGet("brands")]
    [ProducesResponseType(typeof(IEnumerable<CatalogBrandDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBrands()
    {
        var result = await _service.Get();

        return Ok(result);
    }
    
    [HttpGet("brands/{id}")]
    [ProducesResponseType(typeof(CatalogBrandDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetBrandById([FromRoute] int id)
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
    public async Task<IActionResult> CreateBrand(string brand)
    {
        var result = await _service.Add(brand);

        if (result is null)
        {
            return UnprocessableEntity(new WebApiErrorResponse((int)HttpStatusCode.UnprocessableEntity, null, null));
        }

        return Ok(new AddSomeItemResponse<int?> {Id = result});
    }
    
    [HttpPut("update/{id}")]
    [ProducesResponseType(typeof(AddSomeItemResponse<int?>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> UpdateBrandById(CatalogBrandDto dto)
    {
        var result = await _service.Update(dto);

        if (result is null)
        {
            return NotFound(new WebApiErrorResponse((int)HttpStatusCode.NotFound, null, null));
        }

        return Ok(result);
    }
    
    [HttpPut("delete/{id}")]
    [ProducesResponseType(typeof(AddSomeItemResponse<int?>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> DeleteBrand([FromRoute] int id)
    {
        var result = await _service.Remove(id);

        if (result is false)
        {
            return NotFound(new WebApiErrorResponse((int)HttpStatusCode.NotFound, null, null));
        }

        return Ok(result);
    }
}