namespace ElectricalAppliances.Models
{
	public class House
	{
        public List<ElectronicDevice> HouseDevices { get; set; }
        public ElectricalOutlet[] ElectricalOutlets { get; set; }
    }
}
