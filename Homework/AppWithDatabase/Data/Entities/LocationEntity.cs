namespace AppWithDatabase.Data.Entities;

public class LocationEntity
{
    public int Id { get; set; }
    public string LocationName { get; set; }
    
    public IEnumerable<PetEntity> Pets { get; set; } = null!;
}