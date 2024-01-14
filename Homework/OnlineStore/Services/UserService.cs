using Models;

namespace Services
{
	public class UserService
	{
		public User CreateUser()
		{
			User newUser = new();

			Console.WriteLine("\nPlease enter user data for creating payment invoice: ");

			Console.Write("First Name: ");
			newUser.UserFirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            newUser.UserLastName = Console.ReadLine();

            Console.Write("Email (optional): ");
            newUser.UserEmail = Console.ReadLine();

			newUser.UserGuid = Guid.NewGuid();

			if (string.IsNullOrWhiteSpace(newUser.UserFirstName) && string.IsNullOrWhiteSpace(newUser.UserLastName))
			{
				newUser.UserFirstName = "Customer";
				newUser.UserLastName = newUser.UserGuid.ToString();
			}

			return newUser;
        }
	}
}

