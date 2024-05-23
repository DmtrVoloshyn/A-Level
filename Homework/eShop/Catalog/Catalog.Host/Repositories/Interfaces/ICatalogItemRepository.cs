using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Repositories.Interfaces;

public interface ICatalogItemRepository
{
    Task<PaginatedItems<CatalogItem>> GetByPage(
        string? brandTitle, 
        string? typeTitle,
        int pageIndex, 
        int pageSize);
    
    Task<CatalogItem?> GetById(int id);
    
    Task<int?> Create(string name, 
        string description, 
        decimal price, 
        int availableStock, 
        int catalogBrandId, 
        int catalogTypeId, 
        string? pictureFileName);
    
    Task<int> Update(int id, 
        string name, 
        string description, 
        decimal price, 
        int availableStock, 
        int catalogBrandId, 
        int catalogTypeId, 
        string? pictureFileName);
    
    Task<bool> Delete(int id);
}