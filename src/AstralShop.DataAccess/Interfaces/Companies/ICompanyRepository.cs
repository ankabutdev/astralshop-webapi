using AstralShop.DataAccess.Common.Interface;
using AstralShop.Domain.Entities.Companies;

namespace AstralShop.DataAccess.Interfaces.Companies;

public interface ICompanyRepository : IRepository<Company, Company>,
    IGetAll<Company>
{
}
