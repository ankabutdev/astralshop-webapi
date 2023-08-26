using AstralShop.DataAccess.Interfaces;
using AstralShop.Domain.Entities.Categories;
using AstralShop.Domain.Entities.Products;
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

    public async Task<bool> CreateAsync(CategoryCreateDto dto)
    {
        var existingCategory = await _unitOfWork.CategoryRepository
            .SelectAsync(x => x.Id == dto.CategoryId);
        if (existingCategory != null)
            throw new CategoryNotFoundException();

        var category = _mapper.Map<Category>(dto);
        var addedCategory = await _unitOfWork
            .CategoryRepository.AddAsync(category);
        await _unitOfWork.SaveAsync();

        //var resultDto = _mapper.Map<>(addedCategory);
       
    }
}