using ElectricalAppliances.Entities;
using ElectricalAppliances.Repositories.Abstractions;

namespace ElectricalAppliances.Repositories
{
    public abstract class MockRepository<T> : IRepository<T> where T : IEntity
    {
        protected List<T> Items { get; }

        protected MockRepository()
        {
            Items = new List<T>();
        }

        public abstract T Get(Guid id);
        public abstract List<T> GetAll();
        public abstract void MockItems();
    }
}
