using AstralShop.Service.DTOs.Categories;
using AstralShop.Service.Interfaces.Categories;
using Microsoft.AspNetCore.Mvc;

namespace AstralShop.WebApi.Controllers.Categories;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoriesController(ICategoryService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CategoryCreateDto dto)
        => Ok(await _service.CreateAsync(dto));
}
