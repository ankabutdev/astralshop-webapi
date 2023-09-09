namespace AstralShop.Domain.Exceptions.Companies;

public class CompanyAlreadyExistsException : NotFoundException
{
    public CompanyAlreadyExistsException()
    {
        this.TitleMessage = "Company already exists!";
    }
}
