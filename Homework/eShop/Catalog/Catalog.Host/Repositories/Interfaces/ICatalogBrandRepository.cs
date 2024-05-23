using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogBrandRepository
{
    Task<IEnumerable<CatalogBrand>> GetAll();
    
    Task<CatalogBrand?> GetById(int id);
    
    Task<int?> Create(CatalogBrand brand);
    
    Task<int?> Update(CatalogBrand brand);
    
    Task<bool> Delete(int id);
}