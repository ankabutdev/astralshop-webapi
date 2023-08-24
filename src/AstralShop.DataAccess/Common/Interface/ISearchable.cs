using AstralShop.DataAccess.Utils;

namespace AstralShop.DataAccess.Common.Interface;

public interface ISearchable<TModel>
{
    public Task<(int ItemsCount, IList<TModel>)> SearchAsync(string search,
        PaginationParams @params);
}
