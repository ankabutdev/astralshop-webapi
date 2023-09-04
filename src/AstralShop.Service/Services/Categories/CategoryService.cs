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
        var category = await _unitOfWork.CategoryRepository.SelectAsync(u => u.Id == dto.Id);
        if (category is null)
            throw new CategoryNotFoundException();

        var categoryname = category.Name;
        var existingUser2 = await _unitOfWork.CategoryRepository.SelectAsync(u => u.Name == dto.Name);
        if (categoryname != dto.Name && existingUser2 is not null)
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

        await _unitOfWork.CategoryRepository.UpdateAsync(category);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<CategoryResultDto>(category);
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