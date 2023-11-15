using AstralShop.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AstralShop.Service.DTOs.Users;

public class UserCreateDto
{
    [MaxLength(13)]
    public string PhoneNumber { get; set; } = string.Empty;

    public bool PhoneNumberConfirmed { get; set; }

    public string PasswordHash { get; set; } = string.Empty;

    public string Salt { get; set; } = string.Empty;

    public DateTime LastActivity { get; set; }

    public IdentityRole IdentityRole { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(9)]
    public string PasswordSeriaNumber { get; set; } = string.Empty;

    public bool IsMale { get; set; }

    public DateOnly BirthDate { get; set; }

    public string Country { get; set; } = string.Empty;

    public string Region { get; set; } = string.Empty;

    public IFormFile? ImagePath { get; set; }
}
