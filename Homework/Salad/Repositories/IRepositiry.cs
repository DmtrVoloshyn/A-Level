using Salad.Entities;

namespace Salad.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        public void Add(T entity);
        public T Get(Guid id);
        public T[] GetAll();
    }
}

