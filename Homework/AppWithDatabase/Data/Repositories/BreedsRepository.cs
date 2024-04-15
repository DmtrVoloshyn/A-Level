using AppWithDatabase.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppWithDatabase.Data.Repositories;

public class BreedsRepository : IRepository<BreedEntity>
{
    private readonly AppDbContext _dbContext;

    public BreedsRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<BreedEntity>> GetAll()
    {
        return await _dbContext.Breeds
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<BreedEntity?> GetById(int id)
    {
        return await _dbContext.Breeds
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<BreedEntity>> GetByPage(int page, int count)
    {
        return await _dbContext.Breeds
            .AsNoTracking()
            .Skip((page - 1) * count)
            .Take(count)
            .ToListAsync();
    }

    public async Task Add(BreedEntity breed)
    {
        await _dbContext.Breeds.AddAsync(breed);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task AddRange(List<BreedEntity> breeds)
    {
        await _dbContext.AddRangeAsync(breeds);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(int id, BreedEntity breed)
    {
        await _dbContext.Breeds
            .Where(c => c.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p
                    .BreedName, breed.BreedName));
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        await _dbContext.Breeds
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
        await _dbContext.SaveChangesAsync();
    }
}