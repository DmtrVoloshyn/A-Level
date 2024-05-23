using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogTypeService
{
    Task<IEnumerable<CatalogTypeDto>> Get();
    Task<CatalogTypeDto> GetById(int id);
    Task<int?> Add(int id, string type);
    Task<int?> Update(int id, string type);
    Task<int?> Remove(int id);
}