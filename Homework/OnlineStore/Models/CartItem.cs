namespace Models
{
	public class CartItem
	{
        public string? CartId { get; set; }
        public DateTime DateCreated { get; set; }
        public int[] ProductIds { get; set; }
    }
}

