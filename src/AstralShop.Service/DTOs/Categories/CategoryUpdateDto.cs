using Microsoft.AspNetCore.Http;

namespace AstralShop.Service.DTOs.Categories;

public class CategoryUpdateDto
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public IFormFile Image { get; set; } = default!;
}
