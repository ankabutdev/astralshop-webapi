namespace AstralShop.Domain.Exceptions.Users;

public class UserAlreadyExistsException : NotFoundException
{
    public UserAlreadyExistsException()
    {
        this.TitleMessage = "User already exists!";
    }
}
