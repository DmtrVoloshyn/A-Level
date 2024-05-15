namespace WebApplicationHomework.Controllers
{
    public class ProductDto
    {
        public ProductDto(Product model)
        {
            Product = new Product(
                model.Id,
                model.Name,
                model.PriceCents,
                model.Description ?? ""
            );
        }

        public Product Product { get; set; }
    }
}