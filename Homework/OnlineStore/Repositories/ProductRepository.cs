using System.Text;
using Models;
using Services;

namespace Repositories
{
	public class ProductRepository
    {
        public List<Device>? Devices { get; private set; } = ProductService.CreateDevices();


            public List<Device> GetAvailableProducts()
        {
            Console.WriteLine("Mobile Devices:");
            string mobileDevices = GetAvailableMobileDevices(Devices.OfType<Smartphone>().ToList());
            Console.WriteLine(mobileDevices);

            Console.WriteLine("\nComputers:");
            string computers = GetAvailableComputers(Devices.OfType<Computer>().ToList());
            Console.WriteLine(computers);
            return Devices;
        }

        private string GetAvailableMobileDevices(List<Smartphone> smartphones)
        {
            StringBuilder listOfMobileDevices = new();

            foreach (var smartphone in smartphones)
            {
                listOfMobileDevices.AppendLine($"Product ID: {smartphone.ProductId} " +
                    $"Name: {smartphone.ProductName} " +
                    $"Price: {smartphone.Price:C}");
                listOfMobileDevices.AppendLine($"\tBrand: {smartphone.Brand};");
                listOfMobileDevices.AppendLine($"\tModel: {smartphone.Model};");
                listOfMobileDevices.AppendLine($"\tOS: {smartphone.OperatingSystem};");
                listOfMobileDevices.AppendLine($"\tMemory: {smartphone.Memory}GB;");
                listOfMobileDevices.AppendLine();
            }

            return listOfMobileDevices.ToString();
        }

        private string GetAvailableComputers(List<Computer> computers)
        {
            StringBuilder listOfComputers = new();

            foreach (var computer in computers)
            {
                listOfComputers.AppendLine($"Product ID: {computer.ProductId} " +
                    $"Name: {computer.ProductName} " +
                    $"Price: {computer.Price:C}");
                listOfComputers.AppendLine($"\tBrand: {computer.Brand};");
                listOfComputers.AppendLine($"\tModel: {computer.Model};");
                listOfComputers.AppendLine($"\tOS: {computer.OperatingSystem};");
                listOfComputers.AppendLine();
            }

            return listOfComputers.ToString();
        }
    }
}

