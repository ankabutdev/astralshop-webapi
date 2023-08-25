using AstralShop.DataAccess.Common.Interface;
using AstralShop.Domain.Entities.Discounts;

namespace AstralShop.DataAccess.Interfaces.Discounts;

public interface IDiscountRepository : IRepository<Discount>,
    IGetAll<Discount>
{
}