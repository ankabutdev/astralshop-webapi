namespace AstralShop.Service.DTOs.Products;

public class ProductRusultDto
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public long CategoryId { get; set; }

    public long CompanyId { get; set; }

    public string ImagePath { get; set; } = string.Empty;

    public double UnitPrice { get; set; }
}