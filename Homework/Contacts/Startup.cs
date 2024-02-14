using System.Globalization;
using Contacts.Services.Abstractions;

namespace Contacts
{
	public class Startup
	{
		private readonly IContactService _contactService;

		public Startup(IContactService contactService)
		{
			_contactService = contactService;
		}

		public void Start()
		{
			CultureInfo cultureInfo;

            Console.WriteLine("Select the culture: 'UK' - press 'y' or 'US' - press 'n'");

			char input;
			do
			{
				input = char.ToLower(Console.ReadKey().KeyChar);
			} while (input != 'y' && input != 'n');

			if (input == 'y')
			{
				cultureInfo = new CultureInfo("uk-UK");
            }
			else
			{
                cultureInfo = new CultureInfo("en-EN");
            }

            _contactService.DisplayContactsByCulture(cultureInfo);
		}
	}
}