namespace AstralShop.Service.DTOs.Categories;

public class CategoryResultDto
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;
}
