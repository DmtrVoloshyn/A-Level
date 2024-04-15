using AppWithDatabase.Converters;
using AppWithDatabase.Data.Entities;
using AppWithDatabase.Data.Models;
using AppWithDatabase.Data.Repositories;
using AppWithDatabase.Services.Abstractions;

namespace AppWithDatabase.Services;

public class CategoryService : IService<Category>
{
    private readonly IRepository<CategoryEntity> _repository;
    
    public CategoryService(IRepository<CategoryEntity> repository)
    {
        _repository = repository;
    }
    
    public async Task AddRange(List<Category> categories)
    {
        await _repository.AddRange(categories.ToEntityList());
    }

    public async Task Update(int id, Category category)
    {
        await _repository.Update(id, category.ToEntity());
    }

    public async Task<Category> Get(int id)
    {
        var result = await _repository.GetById(id) ?? default;
        return result.ToModel();
    }

    public async Task<List<Category>> GetAll()
    {
        var result = await _repository.GetAll();
        return result.ToModelList();
    }

    public async Task Delete(int id)
    {
        await _repository.Delete(id);
    }
}