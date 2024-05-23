using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogTypeRepository : ICatalogTypeRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogTypeRepository> _logger;

    public CatalogTypeRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogTypeRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<IEnumerable<CatalogType>> GetAll()
    {
        return await _dbContext.CatalogTypes
            .OrderBy(e => e.Type)
            .ToListAsync();
    }

    public async Task<CatalogType?> GetById(int id)
    {
        return await _dbContext.CatalogTypes
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<int?> Create(CatalogType type)
    {
        var item = await _dbContext.CatalogTypes.AddAsync(type);
        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<int?> Update(CatalogType type)
    {
        var item = await _dbContext.CatalogTypes
            .FirstOrDefaultAsync(e => e.Id == type.Id);

        if (item is not null)
        {
            _dbContext.CatalogTypes.Update(type);

            await _dbContext.SaveChangesAsync();

            return item.Id;
        }

        _logger.Log(LogLevel.Error, $"Item with id {type.Id} not found");
        return null;
    }

    public async Task<bool> Delete(int id)
    {
        var item = await _dbContext.CatalogTypes
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