using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogTypeService
{
    Task<IEnumerable<CatalogTypeDto>> Get();
    Task<CatalogTypeDto> GetById(int id);
    Task<int?> Add(string type);
    Task<CatalogTypeDto> Update(CatalogTypeDto type);
    Task<bool> Remove(int id);
}