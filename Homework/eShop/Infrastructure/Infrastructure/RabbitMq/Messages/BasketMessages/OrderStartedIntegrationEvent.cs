using Infrastructure.Enums;
using Infrastructure.Models.Dtos;

namespace Infrastructure.RabbitMq.Messages.BasketMessages;

public class OrderStartedIntegrationEvent : IntegrationEvent
{
    public OrderStartedIntegrationEvent(Guid id, 
        string buyerId, 
        List<BasketItemDto> basketItemDtos, 
        string name, 
        string surName,
        string email, 
        string fullAddress, 
        PaymentTypes paymentType,
        decimal totalPrice
        ) 
        : base(id)
    {
        BuyerId = buyerId;
        BasketItemDtos = basketItemDtos;
        Email = email;
        FullAddress = fullAddress;
        BuyerName = name;
        BuyerSurName = surName;
        PaymentType = paymentType;
        TotalPrice = totalPrice;
    }
    
    public string BuyerId { get; private set; }
    public string BuyerName { get; set; }
    public string BuyerSurName { get; set; }
    public string Email { get; set; }
    public string FullAddress { get; set; }
    public PaymentTypes PaymentType { get; set; }

    public decimal TotalPrice { get; set; }
    public List<BasketItemDto> BasketItemDtos { get; set; }
}