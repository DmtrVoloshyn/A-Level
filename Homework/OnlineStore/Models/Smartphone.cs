using Entities;
using Enums;

namespace Models
{
	public class Smartphone : Device
	{
		public PhoneOperatingSystem OperatingSystem { get; set; }
        public int Memory { get; set; }
    }
}

