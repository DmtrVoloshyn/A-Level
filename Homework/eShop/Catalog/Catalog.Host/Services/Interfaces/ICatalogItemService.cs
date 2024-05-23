using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogItemService
{
    Task<int?> Add(string name, 
        string description, 
        decimal price, 
        int availableStock, 
        int catalogBrandId, 
        int catalogTypeId, 
        string? pictureFileName);

    Task<CatalogItemDto> GetById(int id);

    Task<PaginatedItems<CatalogItemDto>> Get(int pageSize, int pageIndex, string? brandTitle, string? typeTitle);
    
    Task<int> UpdateItem(int id,
        string name,
        string description,
        decimal price,
        int availableStock,
        int catalogBrandId,
        int catalogTypeId,
        string? pictureFileName);

    Task<bool> DeleteItem(int id);
}