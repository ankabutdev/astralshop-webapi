using AstralShop.DataAccess.Utils;
using AstralShop.Service.DTOs.Products;

namespace AstralShop.Service.Interfaces.Products;

public interface IProductService
{
    public Task<ProductRusultDto> CreateAsync(ProductCreateDto dto);

    public Task<ProductRusultDto> UpdateAsync(ProductUpdateDto dto);

    public Task<bool> DeleteAsync(long productId);

    Task<ProductRusultDto> GetByIdAsync(long productId);

    Task<IEnumerable<ProductRusultDto>> GetAllAsync(PaginationParams @params);

    public Task<long> CountAsync();

    Task<bool> UpdateImageAsync(long productId, string imagePath);
}
