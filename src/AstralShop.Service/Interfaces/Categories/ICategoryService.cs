using AstralShop.DataAccess.Utils;
using AstralShop.Domain.Entities.Categories;
using AstralShop.Service.DTOs.Categories;

namespace AstralShop.Service.Interfaces.Categories;

public interface ICategoryService
{
    public Task<bool> CreateAsync(CategoryCreateDto dto);

    public Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto dto);

    public Task<bool> DeleteAsync(long categoryId);

    public Task<Category> GetByIdAsync(long categoryId);

    public Task<IEnumerable<Category>> GetAllAsync(PaginationParams @params);

    public Task<long> CountAsync();

    public Task<bool> UpdateImageAsync(long categoryId, string imagePath);
}