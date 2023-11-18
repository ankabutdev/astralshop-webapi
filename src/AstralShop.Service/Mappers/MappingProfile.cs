using AstralShop.Domain.Entities.Categories;
using AstralShop.Domain.Entities.Companies;
using AstralShop.Domain.Entities.Products;
using AstralShop.Service.DTOs.Categories;
using AstralShop.Service.DTOs.Companies;
using AstralShop.Service.DTOs.Products;
using AutoMapper;

namespace AstralShop.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Categories

        CreateMap<Category, CategoryCreateDto>().ReverseMap();
        CreateMap<Category, CategoryUpdateDto>().ReverseMap();

        CreateMap<CategoryCreateDto, CategoryUpdateDto>().ReverseMap();

        // Products
        CreateMap<Product, ProductCreateDto>().ReverseMap();
        CreateMap<Product, ProductUpdateDto>().ReverseMap();

        CreateMap<ProductCreateDto, ProductUpdateDto>().ReverseMap();

        // Companies
        CreateMap<Company, CompanyCreateDto>().ReverseMap();
        CreateMap<Company, CompanyUpdateDto>().ReverseMap();

        CreateMap<CompanyCreateDto, CompanyUpdateDto>().ReverseMap();

        // ...
    }
}
