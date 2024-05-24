using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogBrandService
{
    Task<IEnumerable<CatalogBrandDto>> Get();
    Task<CatalogBrandDto> GetById(int id);
    Task<int?> Add(string brand);
    Task<CatalogBrandDto> Update(CatalogBrandDto brand);
    Task<bool> Remove(int id);
}