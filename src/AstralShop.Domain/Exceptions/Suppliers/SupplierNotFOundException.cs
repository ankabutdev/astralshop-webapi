namespace AstralShop.Domain.Exceptions.Suppliers;

public class SupplierNotFOundException : NotFoundException
{
    public SupplierNotFOundException()
    {
        this.TitleMessage = "Supplier not found!";
    }
}
