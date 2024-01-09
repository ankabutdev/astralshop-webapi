using AstralShop.DataAccess.Utils;
using AstralShop.Service.DTOs.Companies;
using AstralShop.Service.Interfaces.Companies;
using Microsoft.AspNetCore.Mvc;

namespace AstralShop.WebApi.Controllers.Companies;

[Route("api/companies")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _service;
    private readonly int _maxPageSize = 30;

    public CompaniesController(ICompanyService service)
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
    public async Task<IActionResult> CreateAsync([FromForm] CompanyCreateDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpDelete("{productId}")]
    public async Task<IActionResult> DeleteAsync(long productId)
        => Ok(await _service.DeleteAsync(productId));

    [HttpPut]
    public async Task<IActionResult> UpdateaAsync(long companyId, [FromForm] CompanyUpdateDto dto)
        => Ok(await _service.UpdateAsync(companyId, dto));
}

