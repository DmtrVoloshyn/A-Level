using Microsoft.EntityFrameworkCore;
using OrderProcessor.Data;
using OrderProcessor.Data.Entities;
using OrderProcessor.Repositories.Interfaces;

namespace OrderProcessor.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _dbContext;
    private readonly ILogger<OrderRepository> _logger;

    public OrderRepository(AppDbContext dbContext, ILogger<OrderRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<OrderEntity?> GetById(int id)
    {
        return await _dbContext.Orders.Include(o => o.Buyer)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<int?> Create(OrderEntity order)
    {
        var result = await _dbContext.AddAsync(order);

        await _dbContext.SaveChangesAsync();

        return result.Entity.Id;
    }

    public async Task<bool> Delete(int id)
    {
        var item = await _dbContext.Orders
            .FirstOrDefaultAsync(e => e.Id == id);

        if (item is not null)
        {
            _dbContext.Remove(item);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        
        _logger.LogError($"Item with item_id {id} not found");
        return false;
    }
}