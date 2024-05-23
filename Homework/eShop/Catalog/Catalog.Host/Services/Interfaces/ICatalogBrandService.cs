using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogBrandService
{
    Task<int?> Update(int id, string brand);
    Task<int?> Add(int id, string brand);
    Task<int?> Remove(int brandId);
    Task<IEnumerable<CatalogBrandDto>> Get();
    Task<CatalogBrandDto> GetById(int id);
}