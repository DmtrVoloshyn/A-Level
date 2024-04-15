namespace AppWithDatabase.Data.Repositories;

public interface IRepository<T> 
    where T : class
{
    Task<List<T>> GetAll();
    Task<T?> GetById(int id);
    Task<List<T>> GetByPage(int page, int count);
    Task Add(T entity);
    Task AddRange(List<T> entities);
    Task Update(int id, T updatedModel);
    Task Delete(int id);
}