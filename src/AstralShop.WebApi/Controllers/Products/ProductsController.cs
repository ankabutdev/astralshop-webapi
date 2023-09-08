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

    [HttpPost]
    public async Task<IActionResult> CreateAsync(ProductCreateDto dto)
        => Ok(await _service.CreateAsync(dto));
}