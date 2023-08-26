using AstralShop.Service.DTOs.Categories;
using Microsoft.AspNetCore.Mvc;

namespace AstralShop.WebApi.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IWebHostEnvironment _env;

    public CategoriesController(IWebHostEnvironment env)
    {
        this._env = env;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CategoryCreateDto dto)
    {
        return Ok();
    }
}
