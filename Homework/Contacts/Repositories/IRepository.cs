namespace Contacts.Repositories
{
    public interface IRepository<T>
	{
        public List<T> GetAll();
        public void MockItems();
    }
}
