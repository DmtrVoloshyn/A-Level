namespace WebApplicationHomework.Controllers;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int PriceCents { get; set; }
    public string? Description { get; set; }
    
    public Product(Guid id, string name, int priceCents, string? description = null)
    {
        Id = id;
        Name = name;
        PriceCents = priceCents;
        Description = description;
    }
}