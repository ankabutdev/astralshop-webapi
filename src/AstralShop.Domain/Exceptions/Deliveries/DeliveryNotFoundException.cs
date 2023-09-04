namespace AstralShop.Domain.Exceptions.Deliveries;

public class DeliveryNotFoundException : NotFoundException
{
    public DeliveryNotFoundException()
    {
        this.TitleMessage = "Delivery not found!";
    }
}
