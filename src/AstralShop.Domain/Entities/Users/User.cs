using AstralShop.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace AstralShop.Domain.Entities.Users;

public class User : Human
{
    [MaxLength(13)]
    public string PhoneNumber { get; set; } = string.Empty;

    public bool PhoneNumberConfirmed { get; set; }

    public string PasswordHash { get; set; } = string.Empty;

    public string Salt { get; set; } = string.Empty;

    public DateTime LastActivity { get; set; }

    public IdentityRole IdentityRole { get; set; }
}