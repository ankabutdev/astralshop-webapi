using AstralShop.DataAccess.Interfaces;
using AstralShop.Domain.Entities.Categories;
using AstralShop.Service.DTOs.Categories;
using AstralShop.Service.Interfaces.Categories;
using AutoMapper;
using QueHub.Domain.Exceptions.Categories;

namespace AstralShop.Service.Services.Categories;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
    }

    public async Task<CategoryResultDto> CreateAsync(CategoryCreateDto dto)
    {
        var existingCategory = await _unitOfWork.CategoryRepository
            .SelectAsync(x => x.Name == dto.Name);
        if (existingCategory != null)
            throw new CategoryNotFoundException();

        var category = _mapper.Map<Category>(dto);
        var addedCategory = await _unitOfWork
            .CategoryRepository.AddAsync(category);
        await _unitOfWork.SaveAsync();

        var resultDto = _mapper.Map<CategoryResultDto>(addedCategory);
        return resultDto;
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CategoryResultDto>> GetAllQAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CategoryResultDto>> GetByCategoryIdAsync(long categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryResultDto> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CategoryResultDto>> GetByUserIdAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CategoryResultDto>> SearchAsync(string searchTerm)
    {
        throw new NotImplementedException();
    }

    public Task<CategoryResultDto> UpdateAsync(CategoryCreateDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateImageAsync(long id, string imagePath)
    {
        throw new NotImplementedException();
    }
}