using AstralShop.DataAccess.Utils;
using AstralShop.Service.DTOs.Categories;

namespace AstralShop.Service.Interfaces.Categories;

public interface ICategoryService
{
    public Task<CategoryResultDto> CreateAsync(CategoryCreateDto dto);

    public Task<CategoryResultDto> UpdateAsync(CategoryUpdateDto dto);

    public Task<bool> DeleteAsync(long categoryId);

    public Task<CategoryResultDto> GetByIdAsync(long categoryId);

    public Task<IEnumerable<CategoryResultDto>> GetAllAsync(PaginationParams @params);

    public Task<long> CountAsync();

    Task<bool> UpdateImageAsync(long categoryId, string imagePath);
}