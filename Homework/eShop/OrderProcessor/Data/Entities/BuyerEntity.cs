#pragma warning disable CS8618
namespace OrderProcessor.Data.Entities;

public class BuyerEntity
{
    public int Id { get; set; }
    public string BuyerGuid { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public string Email { get; set; }
    public string FullAddress { get; set; }
    
    public ICollection<OrderEntity> Orders { get; set; }
}