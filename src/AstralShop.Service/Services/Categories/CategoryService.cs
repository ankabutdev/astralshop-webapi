using AstralShop.DataAccess.Interfaces;
using AstralShop.Service.DTOs.Categories;
using AstralShop.Service.Interfaces.Categories;

namespace AstralShop.Service.Services.Categories;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        this._unitOfWork = unitOfWork;
    }

    //public async Task<bool> CreateAsync(CategoryCreateDto dto)
    //{

    //}
}
