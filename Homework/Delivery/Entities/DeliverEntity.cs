namespace Delivery.Entities
{
	public class DeliverEntity
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public VehicleEntity Vehicle { get; set; }
        public Guid VehicleId { get; set; }
    }
}
