using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogItemRepository : ICatalogItemRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogItemRepository> _logger;

    public CatalogItemRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogItemRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int?> Create(CatalogItem item)
    {
        var result = await _dbContext.AddAsync(item);

        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<PaginatedItems<CatalogItem>> GetByPage(string? brandTitle, string? typeTitle, int pageIndex, int pageSize)
    {
        var query = _dbContext.CatalogItems.AsQueryable();

        if (!string.IsNullOrEmpty(brandTitle))
        {
            query = query.Where(i => i.CatalogBrand.Brand == brandTitle);
        }

        if (!string.IsNullOrEmpty(typeTitle))
        {
            query = query.Where(i => i.CatalogType.Type == typeTitle);
        }

        var totalItems = await query.LongCountAsync();

        var itemsOnPage = await query
            .Include(e => e.CatalogBrand)
            .Include(e => e.CatalogType)
            .OrderBy(o => o.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync();

        return new PaginatedItems<CatalogItem> { TotalCount = totalItems, Data = itemsOnPage };
    }
    
    public async Task<CatalogItem?> GetById(int id)
    {
        return await _dbContext.CatalogItems
            .Include(i => i.CatalogBrand)
            .Include(i => i.CatalogType)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<int?> Create(string name, 
        string description, 
        decimal price, 
        int availableStock, 
        int catalogBrandId, 
        int catalogTypeId,
        string? pictureFileName)
    {
        var item = await _dbContext.CatalogItems.AddAsync(
            new CatalogItem
            {
                AvailableStock = availableStock,
                Name = name,
                Description = description,
                Price = price,
                CatalogBrandId = catalogBrandId,
                CatalogTypeId = catalogTypeId,
                PictureFileName = pictureFileName ?? ""
            });
        
        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<CatalogItem> Update(CatalogItem item)
    {
        _dbContext.Attach(item);
        _dbContext.Entry(item).Property(x => x.Name).IsModified = true;
        _dbContext.Entry(item).Property(x => x.Description).IsModified = true;
        _dbContext.Entry(item).Property(x => x.Price).IsModified = true;
        await _dbContext.SaveChangesAsync();
        return item;
    }

    public async Task<bool> Delete(int id)
    {
        var item = await _dbContext.CatalogItems
            .FirstOrDefaultAsync(e => e.Id == id);

        if (item is not null)
        {
            _dbContext.Remove(item);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        
        _logger.Log(LogLevel.Error, $"Item with item_id {id} not found");
        return false;
    }
}