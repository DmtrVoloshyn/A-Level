namespace Delivery.Models
{
	public class DeliveryInfo
	{
		public Order Order { get; set; }
		public Deliver Deliver { get; set; }
        public int ApproxDeliveryMinutes { get; set; }
	}
}

