namespace Infrastructure.Models.Dtos
{
    public class BasketItemDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int Quantity { get; set; }
    }
}