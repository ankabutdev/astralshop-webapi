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

    public async Task<long> CountAsync() =>
      await _unitOfWork.CategoryRepository.SelectAll().CountAsync();

    public async Task<bool> CreateAsync(CategoryCreateDto dto)
    {
        var existingCategory = await _unitOfWork.CategoryRepository
            .SelectAsync(x => x.Name == dto.Name);
        if (existingCategory != null)
            throw new CategoryAlreadyExistsException();

        string imagePath = await _fileService.UploadImageAsync(dto.Image);

        var category = _mapper.Map<Category>(dto);

        category.ImagePath = imagePath;

        category.UpdatedAt = TimeHelper.GetDateTime();

        var result = await _unitOfWork
            .CategoryRepository.AddAsync(category);

        await _unitOfWork.SaveAsync();

        // ternary if
        return result is null ? false : true;
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

    public async Task<IEnumerable<Category>> GetAllAsync(PaginationParams @params)
    {
        var categories = _unitOfWork.CategoryRepository.SelectAll();

        var paginatedQuery = categories
            .Skip(@params
            .GetSkipCount())
            .Take(@params.PageSize);

        var resultDto = await paginatedQuery.ToListAsync();

        return resultDto;
    }

    public async Task<Category> GetByIdAsync(long id)
    {
        var category = await _unitOfWork.CategoryRepository
            .SelectAsync(x => x.Id == id);

        if (category is null)
            throw new CategoryNotFoundException();

        return category;
    }

    public async Task<bool> UpdateAsync(long categoryId, CategoryUpdateDto dto)
    {
        var category = await _unitOfWork.CategoryRepository.SelectAsync(u => u.Id == categoryId);
        if (category is null)
            throw new CategoryNotFoundException();

        var categoryname = category.Name;
        var existingcategory = await _unitOfWork.CategoryRepository.SelectAsync(u => u.Name == dto.Name);
        if (categoryname != dto.Name && existingcategory is not null)
            throw new CategoryAlreadyExistsException();

        string newImagePath = category.ImagePath;

        if (dto.ImagePath is not null)
        {
            // Delete old image
            var deleteResult = await _fileService.DeleteImageAsync(category.ImagePath);
            if (!deleteResult)
                throw new ImageNotFoundException();

            // Upload new image
            newImagePath = await _fileService.UploadImageAsync(dto.ImagePath);
        }
        // else category old image have to save

        _mapper.Map(dto, category);

        category.UpdatedAt = TimeHelper.GetDateTime();
        category.ImagePath = newImagePath;

        var result = await _unitOfWork.CategoryRepository.UpdateAsync(category);
        await _unitOfWork.SaveAsync();

        // ternary if
        return result is null ? false : true;
    }

    public async Task<bool> UpdateImageAsync(long id, string imagePath)
    {
        var category = await _unitOfWork.CategoryRepository.SelectAsync(x => x.Id == id);
        if (category is null)
            throw new CategoryNotFoundException();

        category.ImagePath = imagePath;
        await _unitOfWork.CategoryRepository.UpdateAsync(category);
        await _unitOfWork.SaveAsync();

        return true;
    }
}