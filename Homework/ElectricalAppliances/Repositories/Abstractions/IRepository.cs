using ElectricalAppliances.Entities;

namespace ElectricalAppliances.Repositories.Abstractions
{
	public interface IRepository<T> where T : IEntity
	{
        public T Get(Guid id);
        public List<T> GetAll();
        public void MockItems();
    }
}

