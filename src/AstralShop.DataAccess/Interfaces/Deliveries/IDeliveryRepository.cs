using AstralShop.DataAccess.Common.Interface;
using AstralShop.DataAccess.ViewModels.Deliveries;
using AstralShop.Domain.Entities.Deliveries;

namespace AstralShop.DataAccess.Interfaces.Deliveries;

public interface IDeliveryRepository : IRepository<Deliver, Deliver>,
    IGetAll<DeliveryViewModel>
{
    public Task<DeliveryViewModel> GetDeliveryAsync(long id);
}
