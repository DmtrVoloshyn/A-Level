
using Contacts.Entities;

namespace Contacts.Repositories
{
    public class ContactRepository : IRepository<ContactEntity>
    {
        private List<ContactEntity> _сontacts = new();

		public ContactRepository()
		{
            MockItems();
        }

        public List<ContactEntity> GetAll()
        {
            return _сontacts;
        }


        public void MockItems()
        {
            _сontacts.Add(new ContactEntity { Name = "Ivan Talabira", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = "Petro Ivanov", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = "Antin Kuts", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = "Valeriy", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = "Сантехнік", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = "Автомийка", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = "Ян", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = ".net", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = "////", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = "John Smith", Phone = "1234567890" });
            _сontacts.Add(new ContactEntity { Name = "Emily Davis", Phone = "9876543210" });
            _сontacts.Add(new ContactEntity { Name = "David Johnson", Phone = "5555555555" });
            _сontacts.Add(new ContactEntity { Name = "Olivia White", Phone = "5551234567" });
            _сontacts.Add(new ContactEntity { Name = "Liam Brown", Phone = "5559876543" });
            _сontacts.Add(new ContactEntity { Name = "Sophia Wilson", Phone = "5554445555" });
            _сontacts.Add(new ContactEntity { Name = "James Lee", Phone = "5552223333" });
            _сontacts.Add(new ContactEntity { Name = "Emma Taylor", Phone = "5556667777" });
            _сontacts.Add(new ContactEntity { Name = "Logan Miller", Phone = "5558889999" });
            _сontacts.Add(new ContactEntity { Name = "Ava Jackson", Phone = "5551110000" });
            _сontacts.Add(new ContactEntity { Name = "Іван Талабіра", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = "Петро Іванов", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = "Антін Куц", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = "Валерій", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = "Сантехнік", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = "Автомийка", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = "Олексій", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = "Наталія", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = "Ігор", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = "Людмила", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = "Ірина", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = "Олена", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = "Михайло", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = "Анастасія", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = "Сергій", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = "Вікторія", Phone = "380995552233" });
            _сontacts.Add(new ContactEntity { Name = "12345", Phone = "5555555555" });
            _сontacts.Add(new ContactEntity { Name = "67890", Phone = "5556666666" });
            _сontacts.Add(new ContactEntity { Name = "11111", Phone = "5557777777" });
            _сontacts.Add(new ContactEntity { Name = "99999", Phone = "5558888888" });
        }
    }
}