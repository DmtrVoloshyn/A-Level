namespace AppWithDatabase.Data.Entities;

public class CategoryEntity
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public IEnumerable<BreedEntity> Breeds { get; set; } = null!;
    public IEnumerable<PetEntity> Pets { get; set; } = null!;
}