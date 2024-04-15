using AppWithDatabase.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppWithDatabase.Data.Repositories;

public class PetsRepository : IRepository<PetEntity>
{
    private readonly AppDbContext _dbContext;

    public PetsRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<PetEntity>> GetAll()
    {
        return await _dbContext.Pets
            .AsNoTracking()
            .Include(b => b.Breed)
            .Include(c => c.Category)
            .Include(l => l.Location)
            .ToListAsync();
    }

    public async Task<PetEntity?> GetById(int id)
    {
        return await _dbContext.Pets
            .AsNoTracking()
            .Include(b => b.Breed)
            .Include(c => c.Category)
            .Include(l => l.Location)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<PetEntity>> GetByPage(int page, int count)
    {
        return await _dbContext.Pets
            .AsNoTracking()
            .Include(b => b.Breed)
            .Include(c => c.Category)
            .Include(l => l.Location)
            .Skip((page - 1) * count)
            .Take(count)
            .ToListAsync();
    }

    public async Task Add(PetEntity pet)
    {
        await _dbContext.Pets.AddAsync(pet);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task AddRange(List<PetEntity> pets)
    {
        await _dbContext.AddRangeAsync(pets);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(int id, PetEntity pet)
    {
        await _dbContext.Pets
            .Where(c => c.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p.Description, pet.Description)
                .SetProperty(p => p.BreedId, pet.BreedId)
                .SetProperty(p => p.Age, pet.Age)
                .SetProperty(p => p.Name, pet.Name)
                .SetProperty(p => p.CategoryId, pet.CategoryId) // Обновление ID категории
                .SetProperty(p => p.LocationId, pet.LocationId)
                .SetProperty(p => p.ImageUrl, pet.ImageUrl));
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        await _dbContext.Pets
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
        await _dbContext.SaveChangesAsync();
    }
}