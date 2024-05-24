using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogItemService
{
    Task<int?> Add(CreateItemRequest request);

    Task<CatalogItemDto> GetById(int id);

    Task<PaginatedItems<CatalogItemDto>> Get(int pageSize, int pageIndex, string? brandTitle, string? typeTitle);

    Task<CatalogItemDto> Update(UpdateItemRequest request);

    Task<bool> Remove(int id);
}