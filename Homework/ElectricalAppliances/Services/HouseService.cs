using ElectricalAppliances.Repositories;
using AutoMapper;
using ElectricalAppliances.Models;
using ElectricalAppliances.Enums;

namespace ElectricalAppliances.Services
{
	public class HouseService : IHouseService
	{
		private List<ElectronicDevice> availableDevices = new();
        private House myHouse;


        private readonly ElectricalDevicesRepository _eDevicesRepository;
		private readonly ILoggerService _logger;
		private readonly IMapper _mapper;

		public HouseService(ILoggerService logger, ElectricalDevicesRepository eDevicesRepository, IMapper mapper)
		{
			_eDevicesRepository = eDevicesRepository;
			_logger = logger;
			_mapper = mapper;
            availableDevices = _mapper.Map<List<ElectronicDevice>>(_eDevicesRepository.GetAll());
            myHouse = new() { ElectricalOutlets = new ElectricalOutlet[availableDevices.Count] };
        }

        public void ProcessHouse()
        {
            AddAvailableDevicesToHouse();
            PlugInAppliances();
        }

		private void AddAvailableDevicesToHouse()
		{
            foreach (var device in availableDevices)
            {
                if (device is Fridge)
                {
                    myHouse.Fridge = (Fridge)device;
                }
                else if (device is Dishwasher)
                {
                    myHouse.Dishwasher = (Dishwasher)device;
                }
                else if (device is Vacuum)
                {
                    myHouse.Vacuum = (Vacuum)device;
                }
                else if (device is AirConditioner)
                {
                    myHouse.AirConditioner = (AirConditioner)device;
                }
                _logger.Log(LogType.Info, "Device added to house model");
            }
        }

        private void PlugInAppliances()
        {
            foreach (var device in availableDevices)
            {
                ElectricalOutlet freeOutlet = Array.Find(myHouse.ElectricalOutlets, outlet => outlet != null && !outlet.IsPluggedIn);

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
    }
}

