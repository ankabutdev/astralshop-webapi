using AstralShop.DataAccess.Common.Interface;
using AstralShop.DataAccess.ViewModels.Products;
using AstralShop.Domain.Entities.Products;

namespace AstralShop.DataAccess.Interfaces.Products;

public interface IProductRepository : IRepository<Product, ProductViewModel>,
    IGetAll<ProductViewModel>, ISearchable<ProductViewModel>
{
}