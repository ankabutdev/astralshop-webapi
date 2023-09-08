namespace AstralShop.Domain.Exceptions.Products;

public class ProductAlreadyExistsException : NotFoundException
{
    public ProductAlreadyExistsException()
    {
        this.TitleMessage = "Product already exists!";
    }
}