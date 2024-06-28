using OrderProcessor.Data.Entities;

namespace OrderProcessor.Repositories.Interfaces;

public interface IOrderRepository
{
    Task<OrderEntity?> GetById(int id);

    Task<int?> Create(OrderEntity order);
    
    Task<bool> Delete(int id);
}