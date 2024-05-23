using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories;

public interface ICatalogTypeRepository
{
    Task<IEnumerable<CatalogType>> GetAll();
    
    Task<CatalogType?> GetById(int id);
    
    Task<int?> Create(CatalogType type);
    
    Task<int?> Update(CatalogType type);
    
    Task<bool> Delete(int id);
}