using AstralShop.DataAccess.Utils;
using AstralShop.Service.DTOs.Categories;
using AstralShop.Service.Interfaces.Categories;
using Microsoft.AspNetCore.Mvc;

namespace AstralShop.WebApi.Controllers.Categories;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _service;
    //private readonly int _maxPageSize = 30;

    public CategoriesController(ICategoryService service)
    {
        _service = service;
    }

    [HttpGet("count")]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpGet("{categoryId}")]
    public async Task<IActionResult> GetByIdAsync(long categoryId)
        => Ok(categoryId); //Ok(await _service.GetByIdAsync(categoryId));

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CategoryCreateDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpDelete("{categoryId}")]
    public async Task<IActionResult> DeleteAsync(long categoryId)
        => Ok(await _service.DeleteAsync(categoryId));
}
