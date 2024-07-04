using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogBrandRepository : ICatalogBrandRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogBrandRepository> _logger;

    public CatalogBrandRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogBrandRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }
    
    public async Task<IEnumerable<CatalogBrand>> GetAll()
    {
        return await _dbContext.CatalogBrands
            .OrderBy(e => e.Brand)
            .ToListAsync();
    }

    public async Task<CatalogBrand?> GetById(int id)
    {
        return  await _dbContext.CatalogBrands
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<int?> Create(CatalogBrand brand)
    {
        var item = await _dbContext.CatalogBrands.AddAsync(brand);
        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<CatalogBrand> Update(CatalogBrand brand)
    {
        _dbContext.Attach(brand);
        _dbContext.Entry(brand).Property(x => x.Brand).IsModified = true;
        await _dbContext.SaveChangesAsync();
        return brand;
    }

    public async Task<bool> Delete(int id)
    {
        var item = await _dbContext.CatalogBrands
            .FirstOrDefaultAsync(e => e.Id == id);

        if (item is not null)
        {
            _dbContext.Remove(item);

            await _dbContext.SaveChangesAsync();

            return true;
        }
        
        _logger.Log(LogLevel.Error, $"Item with id {id} not found");
        return false;
    }
}