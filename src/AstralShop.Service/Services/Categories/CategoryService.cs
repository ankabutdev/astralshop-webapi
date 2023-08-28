using AstralShop.DataAccess.Interfaces;
using AstralShop.DataAccess.Utils;
using AstralShop.Domain.Entities.Categories;
using AstralShop.Domain.Exceptions.Categories;
using AstralShop.Domain.Exceptions.Files;
using AstralShop.Service.Common.Helpers;
using AstralShop.Service.DTOs.Categories;
using AstralShop.Service.Interfaces.Categories;
using AstralShop.Service.Interfaces.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

    public async Task<IEnumerable<CategoryResultDto>> GetAllAsync(PaginationParams @params)
    {
        var categories = _unitOfWork.CategoryRepository.SelectAll();
        var paginatedQuery = categories
            .Skip(@params
            .GetSkipCount())
            .Take(@params.PageSize);

        var resultDto = await paginatedQuery.ToListAsync();

        return _mapper.Map<IEnumerable<CategoryResultDto>>(resultDto);

    }

    public async Task<CategoryResultDto> GetByIdAsync(long id)
    {
        var category = await _unitOfWork.CategoryRepository
            .SelectAsync(x => x.Id == id);
        if (category is null)
            throw new CategoryNotFoundException();

        return _mapper.Map<CategoryResultDto>(category);
    }

    public async Task<CategoryResultDto> UpdateAsync(CategoryUpdateDto dto)
    {
        var existingCategory = await _unitOfWork.CategoryRepository.SelectAsync(x => x.Id == dto.Id);
        if (existingCategory is null)
            throw new CategoryNotFoundException();

        var name = existingCategory.Name;
        var existingCategory2 = await _unitOfWork.CategoryRepository.SelectAsync(x => x.Name == dto.Name);
        if (name != dto.Name && existingCategory2 is not null)
            throw new CategoryAlreadyExistsException();

        _mapper.Map(dto, existingCategory);
        await _unitOfWork.CategoryRepository.UpdateAsync(existingCategory);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<CategoryResultDto>(existingCategory);
    }

    public Task<bool> UpdateImageAsync(long id, string imagePath)
    {
        throw new NotImplementedException();
    }
}