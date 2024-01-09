using AstralShop.DataAccess.Utils;
using AstralShop.Service.DTOs.Users;
using AstralShop.Service.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace AstralShop.WebApi.Controllers.Users;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;
    private readonly int _maxPageSize = 30;

    public UsersController(IUserService userService)
    {
        this._service = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, _maxPageSize)));

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] UserCreateDto dto)
        => Ok(await _service.CreateAsync(dto));
}
