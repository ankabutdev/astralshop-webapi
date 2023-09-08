﻿using AstralShop.Domain.Entities.Categories;
using AstralShop.Domain.Entities.Products;
using AstralShop.Service.DTOs.Categories;
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
        CreateMap<Category, CategoryResultDto>().ReverseMap();

        CreateMap<CategoryCreateDto, CategoryUpdateDto>().ReverseMap();
        CreateMap<CategoryCreateDto, CategoryResultDto>().ReverseMap();

        CreateMap<CategoryResultDto, CategoryUpdateDto>().ReverseMap();
        CreateMap<CategoryResultDto, CategoryCreateDto>().ReverseMap();

        // Products
        CreateMap<Product, ProductCreateDto>().ReverseMap();
        CreateMap<Product, ProductUpdateDto>().ReverseMap();
        CreateMap<Product, ProductResultDto>().ReverseMap();

        CreateMap<ProductCreateDto, ProductUpdateDto>().ReverseMap();
        CreateMap<ProductCreateDto, ProductResultDto>().ReverseMap();

        CreateMap<ProductResultDto, ProductUpdateDto>().ReverseMap();
        CreateMap<ProductResultDto, ProductCreateDto>().ReverseMap();
        // ...
    }
}
