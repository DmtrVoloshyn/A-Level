using Catalog.Host.Data;
using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogItemRepository
{
    Task<PaginatedItems<CatalogItem>> GetByPage(
        string? brandTitle, 
        string? typeTitle,
        int pageIndex, 
        int pageSize);
    
    Task<CatalogItem?> GetById(int id);

    Task<int?> Create(CatalogItem item);

    Task<CatalogItem> Update(CatalogItem item);
    
    Task<bool> Delete(int id);
}