using Microsoft.AspNetCore.Http;

namespace AstralShop.Service.DTOs.Categories;

public class CategoryUpdateDto
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public IFormFile? ImagePath { get; set; }
}
