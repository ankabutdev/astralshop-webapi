using AstralShop.DataAccess.Common.Interface;
using AstralShop.Domain.Entities.Categories;

namespace AstralShop.DataAccess.Interfaces.Categories;

public interface ICategoryRepository : IRepository<Category , Category>,
    IGetAll<Category>
{
}
