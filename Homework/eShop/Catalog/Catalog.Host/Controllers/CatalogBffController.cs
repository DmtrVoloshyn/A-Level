using System.Net;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

public class CatalogBffController : BaseController
{
    private readonly ILogger<CatalogBffController> _logger;
    private readonly ICatalogService _catalogService;
    private readonly ICatalogItemService _catalogItemService;
    private readonly ICatalogBrandService _catalogBrandService;
    private readonly ICatalogTypeService _catalogTypeService;


    public CatalogBffController(
        ILogger<CatalogBffController> logger,
        ICatalogService catalogService,
        ICatalogItemService catalogItemService,
        ICatalogBrandService catalogBrandService, ICatalogTypeService catalogTypeService)
    {
        _logger = logger;
        _catalogService = catalogService;
        _catalogItemService = catalogItemService;
        _catalogBrandService = catalogBrandService;
        _catalogTypeService = catalogTypeService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Items([FromQuery] PaginatedItemsRequest request)
    {
        var result = await _catalogService.GetCatalogItemsAsync(
            request.PageSize, 
            request.PageIndex, 
            brandTitle:null, 
            brandType:null);
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetItemById(int id)
    {
        var result = await _catalogItemService.GetById(id);
        if (result == null)
        {
            return NotFound(new WebApiErrorResponse((int)HttpStatusCode.NotFound, null, null));
        }

        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(PaginatedItems<CatalogItemDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetByBrandName(int pageSize, int pageIndex, string brandTitle)
    {
        var result = await _catalogItemService.Get(pageSize, pageIndex, brandTitle, typeTitle:null);
        if (result == null)
        {
            return NotFound(new WebApiErrorResponse((int)HttpStatusCode.NotFound, null, null));
        }

        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(PaginatedItems<CatalogItemDto>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetByTypeName(int pageSize, int pageIndex, string typeName)
    {
        var result = await _catalogItemService.Get(pageSize, pageIndex, brandTitle:null, typeName);
        if (result == null)
        {
            return NotFound(new WebApiErrorResponse((int)HttpStatusCode.NotFound, null, null));
        }

        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CatalogBrand>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetBrands()
    {
        var brands = await _catalogBrandService.Get();
        if (brands == null)
        {
            return NotFound(new WebApiErrorResponse((int)HttpStatusCode.NotFound, null, null));
        }

        return Ok(brands);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CatalogType>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> GetTypes()
    {
        var types = await _catalogTypeService.Get();
        if (types == null)
        {
            return NotFound(new WebApiErrorResponse((int)HttpStatusCode.NotFound, null, null));
        }

        return Ok(types);
    }
}