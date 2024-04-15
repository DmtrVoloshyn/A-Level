using AppWithDatabase.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppWithDatabase.Data.Repositories;

public class CategoriesRepository : IRepository<CategoryEntity>
{
    private readonly AppDbContext _dbContext;

    public CategoriesRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<CategoryEntity>> GetAll()
    {
        return await _dbContext.Categories
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<CategoryEntity?> GetById(int id)
    {
        return await _dbContext.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<List<CategoryEntity>> GetByPage(int page, int count)
    {
        return await _dbContext.Categories
            .AsNoTracking()
            .Skip((page - 1) * count)
            .Take(count)
            .ToListAsync();
    }

    public async Task Add(CategoryEntity category)
    {
        await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddRange(List<CategoryEntity> categories)
    {
        await _dbContext.AddRangeAsync(categories);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(int id, CategoryEntity category)
    {
        await _dbContext.Categories
            .Where(c => c.Id == id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(p => p
                    .CategoryName, category.CategoryName));
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        await _dbContext.Categories
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();
        await _dbContext.SaveChangesAsync();
    }
}