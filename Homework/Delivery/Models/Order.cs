namespace Delivery.Models
{
	public class Order
	{
		public Guid Number { get; set; }
		public decimal TotalAmount { get; set; }
		public Item Item { get; set; }
	}
}

