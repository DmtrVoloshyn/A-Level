using Infrastructure.Enums;
using Infrastructure.Models.Dtos;

namespace Infrastructure.RabbitMq.Messages.BasketMessages;

public class OrderStartedIntegrationEvent : IntegrationEvent
{
    public OrderStartedIntegrationEvent(Guid id, 
        string basketId, 
        List<BasketItemDto> basketItemDtos, 
        string name, 
        string surName,
        string email, 
        string fullAddress, 
        PaymentTypes paymentType
        ) 
        : base(id)
    {
        BasketId = basketId;
        BasketItemDtos = basketItemDtos;
        Email = email;
        FullAddress = fullAddress;
        BuyerName = name;
        BuyerSurName = surName;
        PaymentType = paymentType;
    }
    
    public string BasketId { get; private set; }
    public string BuyerName { get; set; }
    public string BuyerSurName { get; set; }
    public string Email { get; set; }
    public string FullAddress { get; set; }
    public PaymentTypes PaymentType { get; set; }
    public List<BasketItemDto> BasketItemDtos { get; set; }
}