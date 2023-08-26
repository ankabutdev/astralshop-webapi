using AstralShop.Service.DTOs.Categories;

namespace AstralShop.Service.Interfaces.Categories;

public interface ICategoryService
{
    public Task<bool> CreateAsync(CategoryCreateDto dto);

    public Task<bool> UpdateAsync(CategoryCreateDto dto);

    public Task<bool> DeleteAsync(long id);
}