using System.ComponentModel.DataAnnotations;

namespace Basket.Host.Models;

public class CustomerBasket : IValidatableObject
{
    public string? BuyerId { get; set; }
    public List<BasketItem> BasketItems { get; set; } = [];

    public CustomerBasket() { }

    public CustomerBasket(string customerId)
    {
        BuyerId = customerId;
    }
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();

        if (BasketItems.Any(x => x.Quantity < 1))
        {
            results.Add(new ValidationResult("Invalid number of units", new[] { "Quantity" }));
        }

        return results;
    }
}