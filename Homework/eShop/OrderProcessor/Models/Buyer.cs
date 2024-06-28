namespace OrderProcessor.Models;

public class Buyer
{
    public Buyer(string name, 
        string surName,
        string email, 
        string fullAddress)
    {
        Email = email;
        FullAddress = fullAddress;
        BuyerName = name;
        BuyerSurName = surName;
    }
    public string BuyerGuid { get; set; }
    public string BuyerName { get; init; }
    public string BuyerSurName { get; init; }
    public string Email { get; init; }
    public string FullAddress { get; init; }
}