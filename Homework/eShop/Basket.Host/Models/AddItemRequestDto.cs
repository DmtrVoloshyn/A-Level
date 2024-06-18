using System.ComponentModel.DataAnnotations;

namespace Basket.Host.Models;

public class AddItemRequestDto
{
    [Required]
    public Guid Id { get; set; }
    
    [Required] 
    public string Data { get; set; } = null!;
}