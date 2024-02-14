using System.Globalization;

namespace Contacts.Services.Abstractions
{
	public interface IContactService
	{
        public void DisplayContactsByCulture(CultureInfo cultureInfo);
    }
}