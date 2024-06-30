using Microsoft.EntityFrameworkCore;
using OrderProcessor.Data;
using OrderProcessor.Data.Entities;
using OrderProcessor.Repositories.Interfaces;

namespace OrderProcessor.Repositories;

public class BuyerRepository : IBuyerRepository
{
    private readonly AppDbContext _dbContext;
    
    public BuyerRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<BuyerEntity?> GetById(int id)
    {
        return await _dbContext.Buyers.Include(o => o.Orders)
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<int?> Create(BuyerEntity buyer)
    {
        var result = await _dbContext.AddAsync(buyer);
        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }
}