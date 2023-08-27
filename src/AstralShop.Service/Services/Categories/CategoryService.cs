using AstralShop.DataAccess.Interfaces;
using AstralShop.Domain.Entities.Categories;
using AstralShop.Domain.Exceptions.Files;
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
    private readonly IRepository<Category> _repository;

    public CategoryService(IUnitOfWork unitOfWork,
        IMapper mapper, IFileService fileService,
        IRepository<Category> repository)
    {
        this._unitOfWork = unitOfWork;
        this._mapper = mapper;
        this._fileService = fileService;
        this._repository = repository;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();
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

    public async Task<bool> DeleteAsync(long id)
    {
        var category = await _unitOfWork.CategoryRepository
            .SelectAsync(x => x.Id == id);
        if (category is null)
            throw new CategoryNotFoundException();

        var result = await _fileService.DeleteImageAsync(category.ImagePath);
        if (result == false) throw new ImageNotFoundException();

        var dbResult = await _unitOfWork.CategoryRepository.DeleteAsync(x => x == category);
        await _unitOfWork.SaveAsync();

        return dbResult;
    }

    public Task<IEnumerable<CategoryResultDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<CategoryResultDto> GetByIdAsync(long id)
    {
        var category = await _unitOfWork.CategoryRepository
            .SelectAsync(x => x.Id == id);
        if (category is null)
            throw new CategoryNotFoundException();

        return _mapper.Map<CategoryResultDto>(category);
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