using AstralShop.DataAccess.Utils;

namespace AstralShop.DataAccess.Common.Interface;

public interface IGetAll<TModel>
{
    public Task<IList<TModel>> GetAllAsync(PaginationParams @params);
}
