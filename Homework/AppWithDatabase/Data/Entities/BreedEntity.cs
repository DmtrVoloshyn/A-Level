namespace AppWithDatabase.Data.Entities;

public class BreedEntity
{
    public int Id { get; set; }
    public string BreedName { get; set; }
    public int CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;
    
    public IEnumerable<PetEntity> Pets { get; set; } = null!;
}