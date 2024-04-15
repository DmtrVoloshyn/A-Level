using AppWithDatabase.Converters;
using AppWithDatabase.Data.Entities;
using AppWithDatabase.Data.Models;
using AppWithDatabase.Data.Repositories;
using AppWithDatabase.Services.Abstractions;

namespace AppWithDatabase.Services;

public class LocationService : IService<Location>
{
    private readonly IRepository<LocationEntity> _repository;
    
    public LocationService(IRepository<LocationEntity> repository)
    {
        _repository = repository;
    }
    
    public async Task AddRange(List<Location> locations)
    {
        await _repository.AddRange(locations.ToEntityList());
    }

    public async Task Update(int id, Location location)
    {
        await _repository.Update(id, location.ToEntity());
    }

    public async Task<Location> Get(int id)
    {
        var result = await _repository.GetById(id) ?? default;
        return result.ToModel();
    }

    public async Task<List<Location>> GetAll()
    {
        var result = await _repository.GetAll();
        return result.ToModelList();
    }

    public async Task Delete(int id)
    {
        await _repository.Delete(id);
    }
}