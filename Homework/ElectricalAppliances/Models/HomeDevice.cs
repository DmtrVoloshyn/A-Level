namespace ElectricalAppliances.Models
{
	public class HomeDevice : ElectronicDevice
	{
        public bool HasRemoteControl { get; set; }
        public bool IsSmart { get; set; }
    }
}

