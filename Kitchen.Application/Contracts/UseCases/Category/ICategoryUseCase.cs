using Kitchen.Application.DTOs;

namespace Kitchen.Application.Contracts.UseCases
{
    public interface ICategoryUseCase
    {
        Task<CategoryDto> AddCategory(CategoryDto category);
        Task<CategoryDto> GetById(Guid id);
        Task<CategoryDto> DeleteById(Guid id);
        Task<CategoryDto> UpdateById(Guid id, CategoryDto category);
        Task<FindCategoriesResponseDto> LoadAll(int page, int pageSize, string sortOrder);
    }
}
