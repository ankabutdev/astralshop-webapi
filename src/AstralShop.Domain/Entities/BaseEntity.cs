namespace AstralShop.Domain.Entities;

public abstract class BaseEntity
{
    public long Id { get; set; }
    public Users User { get; set; }
}
