using AstralShop.DataAccess.Interfaces;
using AstralShop.Domain.Entities.Categories;
using AstralShop.Service.Common.Helpers;
using AstralShop.Service.DTOs.Categories;
using AstralShop.Service.Interfaces.Categories;
using AstralShop.Service.Interfaces.Common;
using AutoMapper;
using QueHub.Domain.Exceptions.Categories;

namespace AstralShop.Service.Services.Categories;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IFileService _fileService;

    public CategoryService(IUnitOfWork unitOfWork,
        IMapper mapper, IFileService fileService)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
        this._fileService = fileService;
    }

    public async Task<CategoryResultDto> CreateAsync(CategoryCreateDto dto)
    {
        var existingCategory = await _unitOfWork.CategoryRepository
            .SelectAsync(x => x.Name == dto.Name);
        if (existingCategory != null)
            throw new CategoryNotFoundException();

        string imagePath = await _fileService.UploadImageAsync(dto.Image);

        var category = _mapper.Map<Category>(dto);

        category.ImagePath = imagePath;

        category.UpdatedAt = TimeHelper.GetDateTime();

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