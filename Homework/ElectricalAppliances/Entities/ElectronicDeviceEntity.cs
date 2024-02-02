namespace ElectricalAppliances.Entities
{
	public class ElectronicDeviceEntity : IEntity
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string DeviceName { get; set; }
        public string? Model { get; set; }
        public double EnergyConsumption { get; set; }
        public bool IsPortable { get; set; }
    }
}

