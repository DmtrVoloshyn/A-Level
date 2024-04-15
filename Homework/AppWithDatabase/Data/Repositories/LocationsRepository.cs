using AppWithDatabase.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppWithDatabase.Data.Repositories;

public class LocationsRepository : IRepository<LocationEntity>
{
    private readonly AppDbContext _dbContext;

    public LocationsRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<LocationEntity>> GetAll()
    {
        return await _dbContext.Locations
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<LocationEntity?> GetById(int id)
    {
        return await _dbContext.Locations
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<LocationEntity>> GetByPage(int page, int count)
    {
        return await _dbContext.Locations
            .AsNoTracking()
            .Skip((page - 1) * count)
            .Take(count)
            .ToListAsync();
    }

    public async Task Add(LocationEntity location)
    {
        await _dbContext.Locations.AddAsync(location);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task AddRange(List<LocationEntity> locations)
    {
        await _dbContext.AddRangeAsync(locations);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(int id, LocationEntity location)
    {
        await _dbContext.Locations
            .Where(c => c.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p
                    .LocationName, location.LocationName));
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        await _dbContext.Locations
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
        await _dbContext.SaveChangesAsync();
    }
}