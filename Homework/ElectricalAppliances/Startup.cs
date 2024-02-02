using ElectricalAppliances.Services;

namespace ElectricalAppliances
{
	public class Startup
	{
		private readonly IHouseService _houseService;

        public Startup(IHouseService houseService)
		{
			_houseService = houseService;
		}

		public void Start()
		{
            _houseService.ProcessHouse();

        }
	}
}

