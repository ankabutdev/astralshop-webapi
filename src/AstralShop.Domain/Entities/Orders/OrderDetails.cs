using AstralShop.Domain.Entities.Products;

namespace AstralShop.Domain.Entities.Orders;

public class OrderDetails : Auditable
{
    public long OrderId { get; set; }
    public Order Order { get; set; }

    public long ProductId { get; set; }
    public Product Product { get; set; }

    public int Quantity { get; set; }

    public double TotalPrice { get; set; }

    public double ResultPrice { get; set; }

    public double DiscountPrice { get; set; }
}