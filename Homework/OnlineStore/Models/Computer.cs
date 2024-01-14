using Entities;
using Enums;

namespace Models
{
	public class Computer : Device
	{
		public ComputerOperatingSystem OperatingSystem { get; set; }
	}
}

