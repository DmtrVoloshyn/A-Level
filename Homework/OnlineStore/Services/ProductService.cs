using Enums;
using Models;

namespace Services
{
    public class ProductService
    {

        public static List<Device> CreateDevices()
        {
            return new List<Device>
            {
                    new Smartphone
                    {
                        ProductId = 1,
                        ProductName = "IPhone 15 pro",
                        Price = 1425.99,
                        Brand = "Apple",
                        Model = "iPhone 15",
                        OperatingSystem = PhoneOperatingSystem.iOS,
                        Memory = 256
                    },
                    new Smartphone
                    {
                        ProductId = 2,
                        ProductName = "IPhone 14 pro",
                        Price = 1225.99,
                        Brand = "Apple",
                        Model = "iPhone 14",
                        OperatingSystem = PhoneOperatingSystem.iOS,
                        Memory = 128
                    },
                    new Smartphone
                    {
                        ProductId = 3,
                        ProductName = "IPhone 15",
                        Price = 1100.00,
                        Brand = "Apple",
                        Model = "iPhone 15",
                        OperatingSystem = PhoneOperatingSystem.iOS,
                        Memory = 128
                    },
                    new Computer
                    {
                        ProductId = 4,
                        ProductName = "MacBook air",
                        Price = 1822.00,
                        Brand = "Apple",
                        Model = "MacBook Air",
                        OperatingSystem = ComputerOperatingSystem.macOs
                    },
                    new Computer
                    {
                        ProductId = 5,
                        ProductName = "MacBook pro",
                        Price = 2434.99,
                        Brand = "Apple",
                        Model = "MacBook Pro",
                        OperatingSystem = ComputerOperatingSystem.macOs
                    },
                    new Computer
                    {
                        ProductId = 6,
                        ProductName = "Lenovo Notebook",
                        Price = 800.00,
                        Brand = "Lenovo",
                        Model = "Notebook",
                        OperatingSystem = ComputerOperatingSystem.windows
                    },
                    new Computer
                    {
                        ProductId = 7,
                        ProductName = "Asus Notebook",
                        Price = 1200.99,
                        Brand = "Asus",
                        Model = "Notebook",
                        OperatingSystem = ComputerOperatingSystem.windows
                    },
                    new Computer
                    {
                        ProductId = 8,
                        ProductName = "Lenovo PRObook",
                        Price = 1425.99,
                        Brand = "Lenovo",
                        Model = "PRObook",
                        OperatingSystem = ComputerOperatingSystem.windows
                    },
                    new Computer
                    {
                        ProductId = 9,
                        ProductName = "Xiomi MiBook Lite",
                        Price = 1225.99,
                        Brand = "Xiomi",
                        Model = "MiBook Lite",
                        OperatingSystem = ComputerOperatingSystem.windows
                    },
                    new Computer
                    {
                        ProductId = 10,
                        ProductName = "Xiomi MiBook 1",
                        Price = 1100.00,
                        Brand = "Xiomi",
                        Model = "MiBook 1",
                        OperatingSystem = ComputerOperatingSystem.windows
                    },
                    new Computer
                    {
                        ProductId = 11,
                        ProductName = "Xiomi MiBook 2",
                        Price = 1822.00,
                        Brand = "Xiomi",
                        Model = "MiBook 2",
                        OperatingSystem = ComputerOperatingSystem.windows
                    },
                    new Computer
                    {
                        ProductId = 12,
                        ProductName = "Xiomi MiBook 3",
                        Price = 2434.99,
                        Brand = "Xiomi",
                        Model = "MiBook 3",
                        OperatingSystem = ComputerOperatingSystem.windows
                    },
                    new Computer
                    {
                        ProductId = 13,
                        ProductName = "Lenovo Notebook Limited Edition 3000",
                        Price = 1425.99,
                        Brand = "Lenovo",
                        Model = "Limited Edition 3000",
                        OperatingSystem = ComputerOperatingSystem.windows
                    },
                    new Computer
                    {
                        ProductId = 14,
                        ProductName = "Lenovo Notebook Limited Edition 3001",
                        Price = 1225.99,
                        Brand = "Lenovo",
                        Model = "Limited Edition 3001",
                        OperatingSystem = ComputerOperatingSystem.windows
                    },
                    new Computer
                    {
                        ProductId = 15,
                        ProductName = "Lenovo Notebook Limited Edition 3002",
                        Price = 1500.00,
                        Brand = "Lenovo",
                        Model = "Limited Edition 3002",
                        OperatingSystem = ComputerOperatingSystem.windows
                    },
                    new Computer
                    {
                        ProductId = 16,
                        ProductName = "Lenovo Notebook Limited Edition 3020",
                        Price = 1822.00,
                        Brand = "Lenovo",
                        Model = "Limited Edition 3020",
                        OperatingSystem = ComputerOperatingSystem.windows
                    },
                    new Computer
                    {
                        ProductId = 17,
                        ProductName = "Lenovo Notebook Limited Edition 30800",
                        Price = 2434.99,
                        Brand = "Lenovo",
                        Model = "Limited Edition 30800",
                        OperatingSystem = ComputerOperatingSystem.windows
                    },
                    new Computer
                    {
                        ProductId = 18,
                        ProductName = "Asus Notebook 2",
                        Price = 1425.99,
                        Brand = "Asus",
                        Model = "Notebook 2",
                        OperatingSystem = ComputerOperatingSystem.windows
                    },
                    new Computer
                    {
                        ProductId = 19,
                        ProductName = "Asus Notebook 3",
                        Price = 1225.99,
                        Brand = "Asus",
                        Model = "Notebook 3",
                        OperatingSystem = ComputerOperatingSystem.windows
                    },
                    new Computer
                    {
                        ProductId = 20,
                        ProductName = "Asus Notebook 4",
                        Price = 1100.00,
                        Brand = "Asus",
                        Model = "Notebook 4",
                        OperatingSystem = ComputerOperatingSystem.windows
                    }
            };
         }
    }
}
