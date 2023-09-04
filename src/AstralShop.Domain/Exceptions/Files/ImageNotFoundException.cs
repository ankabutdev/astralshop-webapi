using AstralShop.Domain.Exceptions;

namespace AstralShop.Domain.Exceptions.Files;

public class ImageNotFoundException : NotFoundException
{
    public ImageNotFoundException()
    {
        this.TitleMessage = "Image not found!";
    }
}
