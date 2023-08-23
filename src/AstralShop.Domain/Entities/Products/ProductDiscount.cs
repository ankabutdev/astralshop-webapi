using AstralShop.Domain.Entities.Discounts;

namespace AstralShop.Domain.Entities.Products;

public class ProductDiscount : Auditable
{
    public long ProductId { get; set; }
    public Product Product { get; set; }

    public long DiscountId { get; set; }
    public Discount Discount { get; set; }

    public string Description { get; set; }

    public short Percentage { get; set; }

    public DateTime StartAt { get; set; }

    public DateTime EndAt { get; set; }
}
