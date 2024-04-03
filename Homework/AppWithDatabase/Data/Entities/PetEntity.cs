namespace AppWithDatabase.Data.Entities;

public class PetEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public int BreedId { get; set; }
    public int Age { get; set; }
    public int LocationId { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }

    public CategoryEntity Category { get; set; } = null!;
    public LocationEntity Location { get; set; } = null!;
    public BreedEntity Bread { get; set; } = null!;
}