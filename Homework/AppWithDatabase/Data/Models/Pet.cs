namespace AppWithDatabase.Data.Models;

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public int BreedId { get; set; }
    public int Age { get; set; }
    public int LocationId { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }

    public Category Category { get; set; } = null!;
    public Location Location { get; set; } = null!;
    public Breed Breed { get; set; } = null!;
}