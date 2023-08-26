using AstralShop.Service.DTOs.Categories;

namespace AstralShop.Service.Interfaces.Categories;

public interface ICategoryService
{
    public Task<CategoryResultDto> CreateAsync(CategoryCreateDto dto);

    public Task<CategoryResultDto> UpdateAsync(CategoryCreateDto dto);

    public Task<bool> DeleteAsync(long id);

    Task<CategoryResultDto> GetByIdAsync(long id);

    Task<IEnumerable<CategoryResultDto>> GetAllQAsync();

    Task<IEnumerable<CategoryResultDto>> GetByUserIdAsync(long id);

    Task<IEnumerable<CategoryResultDto>> GetByCategoryIdAsync(long categoryId);

    Task<IEnumerable<CategoryResultDto>> SearchAsync(string search);

    Task<bool> UpdateImageAsync(long id, string imagePath);
}