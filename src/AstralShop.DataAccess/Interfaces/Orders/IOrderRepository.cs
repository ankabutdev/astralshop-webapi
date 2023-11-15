using AstralShop.DataAccess.Common.Interface;
using AstralShop.Domain.Entities.Orders;

namespace AstralShop.DataAccess.Interfaces.Orders;

public interface IOrderRepository : IRepository<Order>,
    IGetAll<Order>, ISearchable<Order>
{
}
