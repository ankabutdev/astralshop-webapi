using AstralShop.Domain.Entities.Suppliers;

namespace AstralShop.Domain.Entities.Products;

public class ProductSupplier : Auditable
{
    public long ProductId { get; set; }
    public Product Product { get; set; }

    public long SupplierId { get; set; }
    public Supplier Supplier { get; set; }

    public int Quantity { get; set; }

    public double UnitPrice { get; set; }

    public string Description { get; set; } = string.Empty;
}