using Contacts.Entities;
using Contacts.Models;

namespace Contacts.Converters
{
	public static class ContactConverter
	{
		public static List<Contact> ToModel(this List<ContactEntity> contactsEntity)
		{
            List<Contact> contacts = new();

            foreach (var contactEntity in contactsEntity)
            {
                var contact = new Contact
                {
                    Name = contactEntity.Name,
                    Phone = contactEntity.Phone
                };
                contacts.Add(contact);
            }
            return contacts;
        }
	}
}

