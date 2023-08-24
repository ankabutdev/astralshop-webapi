namespace QueHub.Domain.Exceptions.Products;

public class ProductNotFoundException : NotFoundException
{
    public ProductNotFoundException()
    {
        this.TitleMessage = "Product not found!";
    }
}
