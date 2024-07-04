using AutoMapper;
using Kitchen.Application.Contracts.UseCases;
using Kitchen.Application.DTOs;
using Kitchen.Application.DTOs.Measurement;
using Kitchen.Application.DTOs.Product;
using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Entities;

namespace Kitchen.Application.Mapping
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            // users
            CreateMap<User, UserDto>().ReverseMap();

            // categories
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<FindCategoriesResponse, FindCategoriesResponseDto>().ReverseMap();

            // groups
            CreateMap<Group, GroupDto>().ReverseMap();
            CreateMap<FindGroupsResponse, FindGroupsResponseDto>().ReverseMap();

            // measures
            CreateMap<Measurement, MeasurementDto>().ReverseMap();
            CreateMap<FindMeasuresResponse, FindMeasuresResponseDto>().ReverseMap();

            // products
            CreateMap<Product, UpdateProduct>().ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<FindProductsResponse, FindProductsResponseDto>().ReverseMap();
            CreateMap<Product, ProductResponseDto>()
                    .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.IngredientsOnProduct));

            CreateMap<IngredientsOnProduct, IngredientResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Ingredient.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Ingredient.Name))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Ingredient.Code))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Ingredient.UnitPrice))
                .ForMember(dest => dest.Measurement, opt => opt.MapFrom(src => new MeasurementDto
                {
                    Id = src.Ingredient.Measurement.Id,
                    Name = src.Measurement
                }))
                .ForMember(dest => dest.Grammage, opt => opt.MapFrom(src => src.Grammage))
                .ForMember(dest => dest.Groups, opt => opt.MapFrom(src => src.Ingredient.GroupsOnIngredient));

            CreateMap<GroupsOnIngredient, GroupDto>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Group.Id))
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Group.Name));
        }
    }
}
