using Microsoft.AspNetCore.Mvc;

namespace WebApplicationHomework.Controllers;

[Controller]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<ProductDto>> Get()
    {
        var mockProducts = new List<ProductDto>
        {
            new ProductDto(new Product (Guid.NewGuid(), "Something", 20000, String.Empty)),
            new ProductDto(new Product (Guid.NewGuid(), "Something", 30000)),
            new ProductDto(new Product (Guid.NewGuid(), "Something", 200000, "bla-bla-bla")),
            new ProductDto(new Product (Guid.NewGuid(), "Something", 800000)),
        };
            
        return Ok(mockProducts);
    }
}