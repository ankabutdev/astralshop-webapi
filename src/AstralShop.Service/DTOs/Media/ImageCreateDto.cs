using Microsoft.AspNetCore.Http;

namespace AstralShop.Service.DTOs.Media;

public class ImageCreateDto
{
    public IFormFile File { get; set; } = default!;
}
