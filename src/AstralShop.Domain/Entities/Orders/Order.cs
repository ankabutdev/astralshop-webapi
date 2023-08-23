using AstralShop.Domain.Entities.Deliveries;
using AstralShop.Domain.Entities.Users;

namespace AstralShop.Domain.Entities.Orders;

public class Order : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }

    public long DeliverId { get; set; }
    public Deliver Deliver { get; set; }

    public string Status { get; set; } = string.Empty;

    // summ all items of order details -> result_price
    public double ProductPrice { get; set; }

    public double DeliveryPrice { get; set; }

    // add total_price + delivery price
    public double ResultPrice { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public string PaymentType { get; set; } = string.Empty;

    public bool IsPaid { get; set; }

    public bool IsContracted { get; set; }

    public string Description { get; set; } = string.Empty;
}