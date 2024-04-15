namespace AppWithDatabase.Data.Models;

public class Breed
{
    public int Id { get; set; }
    public string BreedName { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}