namespace AstralShop.Domain.Exceptions.Discounts;

public class DiscountNotFoundException : NotFoundException
{
    public DiscountNotFoundException()
    {
        this.TitleMessage = "Discount not found!";
    }
}
