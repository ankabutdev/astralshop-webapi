using AstralShop.DataAccess.Utils;
using AstralShop.Service.DTOs.Products;
using AstralShop.Service.Interfaces.Products;

namespace AstralShop.Service.Services.Products;

public class ProductService : IProductService
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProductRusultDto> CreateAsync(ProductCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long productId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductRusultDto>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<ProductRusultDto> GetByIdAsync(long productId)
    {
        throw new NotImplementedException();
    }

    public Task<ProductRusultDto> UpdateAsync(ProductUpdateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateImageAsync(long productId, string imagePath)
    {
        throw new NotImplementedException();
    }
}
