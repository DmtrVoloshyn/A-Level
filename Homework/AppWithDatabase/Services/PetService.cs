using AppWithDatabase.Converters;
using AppWithDatabase.Data.Entities;
using AppWithDatabase.Data.Models;
using AppWithDatabase.Data.Repositories;
using AppWithDatabase.Services.Abstractions;

namespace AppWithDatabase.Services;

public class PetService : IService<Pet>
{
    private readonly IRepository<PetEntity> _petRepository;

    public PetService(IRepository<PetEntity> petRepository)
    {
        _petRepository = petRepository;
    }

    public async Task AddRange(List<Pet> pets)
    {
        await _petRepository.AddRange(pets.ToEntityList());
    }

    public async Task Update(int id, Pet pet)
    {
        await _petRepository.Update(id, pet.ToEntity());
    }

    public async Task<Pet> Get(int id)
    {
        var result = await _petRepository.GetById(id) ?? default;
        return result.ToModel();
    }

    public async Task<List<Pet>> GetAll()
    {
        var result = await _petRepository.GetAll();
        return result.ToModelList();
    }

    public async Task Delete(int id)
    {
        await _petRepository.Delete(id);
    }
}