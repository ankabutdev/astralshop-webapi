using AstralShop.DataAccess.Utils;
using AstralShop.Service.DTOs.Products;

namespace AstralShop.Service.Interfaces.Products;

public interface IProductService
{
    public Task<ProductResultDto> CreateAsync(ProductCreateDto dto);

    public Task<ProductResultDto> UpdateAsync(ProductUpdateDto dto);

    public Task<bool> DeleteAsync(long productId);

    Task<ProductResultDto> GetByIdAsync(long productId);

    Task<IEnumerable<ProductResultDto>> GetAllAsync(PaginationParams @params);

    public Task<long> CountAsync();

    Task<bool> UpdateImageAsync(long productId, string imagePath);
}
