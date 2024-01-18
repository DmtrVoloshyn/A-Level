namespace CandyGift.Entities
{
	public class SweetEntity : IEntity
	{
        public Guid Id { get; set; }
        public int Weight { get; set; }
        public string Manufacturer { get; set; }
    }
}

