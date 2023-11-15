using AstralShop.DataAccess.Common.Interface;
using AstralShop.Domain.Entities.Users;

namespace AstralShop.DataAccess.Interfaces.Users;

public interface IUserRepository : IRepository<User>,
    IGetAll<User>, ISearchable<User>
{
}
