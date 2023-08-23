using System.ComponentModel.DataAnnotations;

namespace AstralShop.Domain.Entities.Categories;

public class Category : Auditable
{
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;
}