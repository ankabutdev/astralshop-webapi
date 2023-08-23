using AstralShop.Domain.Entities.Users;

namespace AstralShop.Domain.Entities.Products;

public class ProductComment : Auditable
{
    public long ProductId { get; set; }
    public Product Product { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }

    public string Comment { get; set; } = string.Empty;

    public bool IsEdited { get; set; }
}