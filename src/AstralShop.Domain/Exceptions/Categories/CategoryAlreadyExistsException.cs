namespace AstralShop.Domain.Exceptions.Categories;

public class CategoryAlreadyExistsException : NotFoundException
{
    public CategoryAlreadyExistsException()
    {
        this.TitleMessage = "Category already exists!";
    }
}
