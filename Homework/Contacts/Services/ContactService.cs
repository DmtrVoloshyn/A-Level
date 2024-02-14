using System.Globalization;
using Contacts.Converters;
using Contacts.Entities;
using Contacts.Repositories;
using Contacts.Services.Abstractions;

namespace Contacts.Services
{
	public class ContactService : IContactService
	{
		private readonly IRepository<ContactEntity> _contactRepository;

        public ContactService(IRepository<ContactEntity> contactRepository)
		{
			_contactRepository = contactRepository;
		}

		public void DisplayContactsByCulture(CultureInfo cultureInfo)
		{
            var contacts = _contactRepository.GetAll().ToModel();
            var contactCollection = new ContactCollection(contacts, cultureInfo);

            foreach (var group in contactCollection)
			{
                Console.WriteLine($"\n\nGroup: {group.Key}");
				foreach (var contact in group.Value)
				{
                    Console.WriteLine($"* {contact.Name} - {contact.Phone}");
				}
            }
        }
	}
}