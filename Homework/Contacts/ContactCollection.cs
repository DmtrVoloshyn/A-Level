using System.Collections;
using System.Globalization;
using Contacts.Models;

namespace Contacts
{
	public class ContactCollection : IEnumerable<KeyValuePair<string, List<Contact>>>
    {
		private string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private Dictionary<string, List<Contact>> _groupedContacts = new();

        public ContactCollection(IEnumerable<Contact> contacts, CultureInfo cultureInfo)
        {
            if (cultureInfo.Name.StartsWith("uk"))
            {
                _alphabet = "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ";
            }

            _alphabet += "0123456789" + "#";

            _groupedContacts = contacts
                .OrderBy(contact => contact.Name)
                .GroupBy(contact => GetGroupKey(contact.Name, _alphabet))
                .ToDictionary(group => group.Key, group => group.ToList());
        }

        private static string GetGroupKey(string name, string alphabet)
        {
            char firstCharacter = alphabet.Contains(name.FirstOrDefault())
				? name.First()
                : '#';

            return char.IsDigit(firstCharacter) ? "0-9" : char.ToUpper(firstCharacter).ToString();
        }

        public IEnumerator<KeyValuePair<string, List<Contact>>> GetEnumerator()
        {
            foreach (var item in _groupedContacts)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _groupedContacts.GetEnumerator();
        }
    }
}