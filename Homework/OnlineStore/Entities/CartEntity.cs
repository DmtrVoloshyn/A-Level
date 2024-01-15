namespace Entities
{
	public class CartEntity
	{
        public string? CartId { get; set; }
        public DateTime DateCreated { get; set; }
        public int[] ProductIds { get; set; }
    }
}

