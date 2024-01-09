using AstralShop.DataAccess.Utils;
using AstralShop.Domain.Entities.Products;
using AstralShop.Service.DTOs.Products;

namespace AstralShop.Service.Interfaces.Products;

public interface IProductService
{
    public Task<bool> CreateAsync(ProductCreateDto dto);

    public Task<bool> UpdateAsync(long productId, ProductUpdateDto dto);

    public Task<bool> DeleteAsync(long productId);

    public Task<Product> GetByIdAsync(long productId);

    public Task<IEnumerable<Product>> GetAllAsync(PaginationParams @params);

    public Task<long> CountAsync();

    public Task<bool> UpdateImageAsync(long productId, string imagePath);
}
