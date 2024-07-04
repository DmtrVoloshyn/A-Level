using OrderProcessor.Data.Entities;

namespace OrderProcessor.Repositories.Interfaces;

public interface IBuyerRepository
{
    Task<BuyerEntity?> GetById(int id);

    Task<int?> Create(BuyerEntity buyer);
}