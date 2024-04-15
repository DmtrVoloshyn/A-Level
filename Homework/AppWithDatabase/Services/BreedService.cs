using AppWithDatabase.Converters;
using AppWithDatabase.Data.Entities;
using AppWithDatabase.Data.Models;
using AppWithDatabase.Data.Repositories;
using AppWithDatabase.Services.Abstractions;

namespace AppWithDatabase.Services;

public class BreedService : IService<Breed>
{
    private readonly IRepository<BreedEntity> _repository;
    
    public BreedService(IRepository<BreedEntity> repository)
    {
        _repository = repository;
    }
    
    public async Task AddRange(List<Breed> breeds)
    {
        await _repository.AddRange(breeds.ToEntityList());
    }

    public async Task Update(int id, Breed breed)
    {
        await _repository.Update(id, breed.ToEntity());
    }

    public async Task<Breed> Get(int id)
    {
        var result = await _repository.GetById(id) ?? default;
        return result.ToModel();
    }

    public async Task<List<Breed>> GetAll()
    {
        var result = await _repository.GetAll();
        return result.ToModelList();
    }

    public async Task Delete(int id)
    {
        await _repository.Delete(id);
    }
}