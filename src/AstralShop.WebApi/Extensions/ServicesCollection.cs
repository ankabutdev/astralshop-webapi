using AstralShop.DataAccess.Interfaces;
using AstralShop.DataAccess.Repositories;
using AstralShop.Service.Interfaces.Categories;
using AstralShop.Service.Interfaces.Common;
using AstralShop.Service.Mappers;
using AstralShop.Service.Services.Categories;
using AstralShop.Service.Services.Common;

namespace AstralShop.WebApi.Extensions;

public static class ServicesCollection
{
    public static void AddCustomerService(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        services.AddScoped<ICategoryService, CategoryService>();
        // ...

        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IFileService, FileService>();
    }
}
