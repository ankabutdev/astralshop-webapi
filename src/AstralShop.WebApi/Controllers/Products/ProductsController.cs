using AstralShop.DataAccess.Utils;
using AstralShop.Service.DTOs.Products;
using AstralShop.Service.Interfaces.Products;
using Microsoft.AspNetCore.Mvc;

namespace AstralShop.WebApi.Controllers.Products;

[Route("api/products")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;
    private readonly int _maxPageSize = 30;

    public ProductsController(IProductService service)
    {
        this._service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, _maxPageSize)));

    [HttpGet("{productId}")]
    public async Task<IActionResult> GetByIdAsync(long productId)
        => Ok(await _service.GetByIdAsync(productId));

    [HttpGet("count")]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] ProductCreateDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpDelete("{productId}")]
    public async Task<IActionResult> DeleteAsync(long productId)
        => Ok(await _service.DeleteAsync(productId));

    public async Task<IActionResult> UpdateAsync([FromForm] ProductUpdateDto dto)
        => Ok(await _service.UpdateAsync(dto));
}