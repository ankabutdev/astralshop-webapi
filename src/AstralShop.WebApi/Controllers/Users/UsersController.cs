using AstralShop.Service.DTOs.Users;
using AstralShop.Service.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;

namespace AstralShop.WebApi.Controllers.Users;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService userService)
    {
        this._service = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
        => Ok();

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] UserCreateDto dto)
        => Ok(await _service.CreateAsync(dto));
}
