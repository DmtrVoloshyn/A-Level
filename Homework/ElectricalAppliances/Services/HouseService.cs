using AutoMapper;
using ElectricalAppliances.Models;
using ElectricalAppliances.Enums;
using ElectricalAppliances.Entities;
using ElectricalAppliances.Repositories.Abstractions;
using ElectricalAppliances.Extensions;

namespace ElectricalAppliances.Services
{
	public class HouseService : IHouseService
	{
		private List<ElectronicDevice> availableDevices = new();
        private House myHouse;


        private readonly IRepository<ElectronicDeviceEntity> _eDevicesRepository;
		private readonly ILoggerService _logger;
		private readonly IMapper _mapper;

		public HouseService(ILoggerService logger, IRepository<ElectronicDeviceEntity> eDevicesRepository, IMapper mapper)
		{
			_eDevicesRepository = eDevicesRepository;
			_logger = logger;
			_mapper = mapper;
            availableDevices = _mapper.Map<List<ElectronicDevice>>(_eDevicesRepository.GetAll());
            myHouse = new()
            {
                HouseDevices = new(),
                ElectricalOutlets = new ElectricalOutlet[]
                {
                    new ElectricalOutlet(),
                    new ElectricalOutlet(),
                    new ElectricalOutlet(),
                    new ElectricalOutlet(),
                    new ElectricalOutlet()
                }
            };
        }

        public void ProcessHouse()
        {
            AddAvailableDevicesToHouse();
            PlugInAppliances();
            Console.WriteLine($"\nTotal power consumption: {CalculatePowerConsumption()} watts/h");

            Console.WriteLine("\nSelect what you want to find: Find devices by brand - x; Energy saving devices - y; Portable devices - u;");
            var criteria = Console.ReadLine()?.Trim();

            if (criteria == "x")
            {
                Console.Write("\nEnter the brand you are looking for: ");
                var brand = Console.ReadLine();
                var result = myHouse.HouseDevices.FindByBrand(brand);
                Console.WriteLine($"There are {brand} brand appliances in the house: {string.Join(", ", result.Select(x => x.DeviceName))}");
            }
            else if (criteria == "y")
            {
                Console.Write("\nEnter the desired energy consumption threshold: ");
                var energyConsumptionInput = Console.ReadLine();

                if (int.TryParse(energyConsumptionInput, out int energyConsumption))
                {
                    var result = myHouse.HouseDevices.FindByEnergyConsumption(energyConsumption);
                    Console.WriteLine($"\nDevices have been found that satisfy the condition of energy consumption < {energyConsumption}: " +
                        $"{string.Join(", ", result.Select(x => x.DeviceName))}");
                }
            }
            else if (criteria == "u")
            {
                var result = myHouse.HouseDevices.FindByIsPortableProperty();
                Console.WriteLine($"\nDevices have been found that satisfy the condition of been portable: ");
            }
            else
            {
                Console.Write("You did not select any types to auth");
                return;
            }
        }

        private void AddAvailableDevicesToHouse()
		{
            foreach (var device in availableDevices)
            {
                if (device is Fridge)
                {
                    myHouse.HouseDevices.Add((Fridge)device);
                }
                else if (device is Dishwasher)
                {
                    myHouse.HouseDevices.Add((Dishwasher)device);
                }
                else if (device is Vacuum)
                {
                    myHouse.HouseDevices.Add((Vacuum)device);
                }
                else if (device is AirConditioner)
                {
                    myHouse.HouseDevices.Add((AirConditioner)device);
                }
                _logger.Log(LogType.Info, "Device added to house model");
            }
        }

        private void PlugInAppliances()
        {
            foreach (var device in availableDevices)
            {
                var freeOutlet = Array.Find(myHouse.ElectricalOutlets, outlet => outlet != null && !outlet.IsPluggedIn);

                if (freeOutlet != null)
                {
                    freeOutlet.PlugInDevices(device);
                }
                else
                {
                    _logger.Log(LogType.Warn, "There are no free sockets. Cannot connect another device.");
                }
            }
        }

        private double CalculatePowerConsumption()
        {
            double totalPowerConsumption = 0;

            foreach (var outlet in myHouse.ElectricalOutlets)
            {
                if (outlet != null && outlet.IsPluggedIn)
                {
                    totalPowerConsumption += outlet.GetPowerConsumption();
                }
            }

            return totalPowerConsumption;
        }
    }
}

