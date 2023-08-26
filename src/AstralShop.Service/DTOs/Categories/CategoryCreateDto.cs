using Microsoft.AspNetCore.Http;

namespace AstralShop.Service.DTOs.Categories;

public class CategoryCreateDto
{
    public long CategoryId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public IFormFile Image { get; set; } = default!;
}