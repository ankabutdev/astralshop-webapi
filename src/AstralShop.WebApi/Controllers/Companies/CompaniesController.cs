using AstralShop.Service.DTOs.Companies;
using AstralShop.Service.Interfaces.Companies;
using Microsoft.AspNetCore.Mvc;

namespace AstralShop.WebApi.Controllers.Companies;

[Route("api/companies")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyService _service;

    public CompaniesController(ICompanyService service)
    {
        this._service = service;
    }

    [HttpGet("count")]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] CompanyCreateDto dto)
        => Ok(await _service.CreateAsync(dto));

    [HttpDelete("{productId}")]
    public async Task<IActionResult> DeleteAsync(long productId)
        => Ok(await _service.DeleteAsync(productId));
}

