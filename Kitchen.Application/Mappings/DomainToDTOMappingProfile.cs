using AutoMapper;
using Kitchen.Application.Contracts.UseCases;
using Kitchen.Application.DTOs;
using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Entities;

namespace Kitchen.Application.Mapping
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<FindCategoriesResponse, FindCategoriesResponseDto>().ReverseMap();
            // groups
            CreateMap<Group, GroupDto>().ReverseMap();
            CreateMap<FindGroupsResponse, FindGroupsResponseDto>().ReverseMap();
        }
    }
}
