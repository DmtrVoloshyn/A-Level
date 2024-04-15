namespace AppWithDatabase.Services.Abstractions;

public interface IService<T>
    where T : class
{
    Task AddRange(List<T> models);
    Task Update(int id, T model);
    Task<T> Get(int id);
    Task<List<T>> GetAll();
    Task Delete(int id);
}