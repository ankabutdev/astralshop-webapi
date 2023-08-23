using AstralShop.Domain.Entities.Categories;
using AstralShop.Domain.Entities.Companies;
using System.ComponentModel.DataAnnotations;

namespace AstralShop.Domain.Entities.Products;

public class Product : Auditable
{
    public long CategoryId { get; set; }
    public Category Category { get; set; }

    public long CompanyId { get; set; }
    public Company Company { get; set; }

    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;

    public double UnitPrice { get; set; }
}