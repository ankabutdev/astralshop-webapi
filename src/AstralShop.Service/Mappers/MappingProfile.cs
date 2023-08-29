using AstralShop.Domain.Entities.Categories;
using AstralShop.Service.DTOs.Categories;
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
        // ...
    }
}
