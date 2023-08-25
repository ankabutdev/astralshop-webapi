using AstralShop.Domain.Entities.Categories;
using Microsoft.AspNetCore.Mvc;

namespace AstralShop.WebApi.Controllers;

[Route("api/categories")]
[ApiController]
public class CategoriesController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] Category category)
    {
        return Ok();
    }
}
