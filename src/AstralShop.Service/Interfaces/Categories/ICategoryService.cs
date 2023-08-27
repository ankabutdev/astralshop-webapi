using AstralShop.Service.DTOs.Categories;

namespace AstralShop.Service.Interfaces.Categories;

public interface ICategoryService
{
    public Task<CategoryResultDto> CreateAsync(CategoryCreateDto dto);

    public Task<CategoryResultDto> UpdateAsync(CategoryCreateDto dto);

    public Task<bool> DeleteAsync(long id);

    Task<CategoryResultDto> GetByIdAsync(long id);

    Task<IEnumerable<CategoryResultDto>> GetAllAsync();

    public Task<long> CountAsync();

    Task<bool> UpdateImageAsync(long id, string imagePath);
}