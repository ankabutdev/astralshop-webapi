using AstralShop.DataAccess.Interfaces;
using AstralShop.DataAccess.Repositories;
using AstralShop.Service.Interfaces.Categories;
using AstralShop.Service.Interfaces.Common;
using AstralShop.Service.Interfaces.Companies;
using AstralShop.Service.Interfaces.Products;
using AstralShop.Service.Interfaces.Users;
using AstralShop.Service.Mappers;
using AstralShop.Service.Services.Categories;
using AstralShop.Service.Services.Common;
using AstralShop.Service.Services.Companies;
using AstralShop.Service.Services.Products;
using AstralShop.Service.Services.Users;

namespace AstralShop.WebApi.Extensions;

public static class ServicesCollection
{
    public static void AddCustomerService(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IFileService, FileService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IUserService, UserService>();
        // ...

    }
}
