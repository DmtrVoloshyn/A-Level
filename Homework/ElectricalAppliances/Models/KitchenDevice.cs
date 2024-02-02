namespace ElectricalAppliances.Models
{
	public abstract class KitchenDevice : ElectronicDevice
    {
		public bool IsConstantEnergyConsumption { get; set; }
    }
}
