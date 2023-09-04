using AstralShop.Domain.Exceptions;

namespace AstralShop.Domain.Exceptions.Categories;

public class CategoryNotFoundException : NotFoundException
{
    public CategoryNotFoundException()
    {
        this.TitleMessage = "Category not found!";
    }
}
