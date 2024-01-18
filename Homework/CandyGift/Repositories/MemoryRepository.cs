using CandyGift.Entities;

namespace CandyGift.Repositories
{
	public abstract class MemoryRepository<T> : IRepository<T> where T : IEntity
	{
        protected List<T> Items { get; }

        protected MemoryRepository()
        {
            Items = new List<T>(); 
        }

        public abstract void Add(T entity);
        public abstract T Get(Guid id);
        public abstract T[] GetAll();
    }
}

