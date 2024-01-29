namespace ElectricalAppliances.Models
{
	public class House
	{
		public Fridge Fridge { get; set; }
		public Dishwasher Dishwasher { get; set; }
		public Vacuum Vacuum { get; set; }
		public AirConditioner AirConditioner { get; set; }
        public ElectricalOutlet[] ElectricalOutlets { get; set; }
	}
}
