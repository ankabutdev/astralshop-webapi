using Microsoft.AspNetCore.Http;

namespace AstralShop.Service.DTOs.Products;

public class ProductCreateDto
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public long CategoryId { get; set; }

    public long CompanyId { get; set; }

    public IFormFile ImagePath { get; set; } = default!;

    public double UnitPrice { get; set; }
}
