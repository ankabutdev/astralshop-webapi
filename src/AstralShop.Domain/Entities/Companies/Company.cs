using System.ComponentModel.DataAnnotations;

namespace AstralShop.Domain.Entities.Companies;

public class Company : Auditable
{
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [MaxLength(13)]
    public string PhoneNumber { get; set; } = string.Empty;

    public string ImagePath { get; set; } = string.Empty;
}