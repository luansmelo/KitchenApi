using Kitchen.Application.DTOs.Category;
using Kitchen.Shared.Responses;

namespace Kitchen.Application.Interfaces.UseCases.Category;

public interface ICategoryUseCase
{
    Task<CategoryDto> AddCategory(CategoryDto category);
    Task<CategoryDto> GetById(Guid id);
    Task<CategoryDto> DeleteById(Guid id);
    Task<CategoryDto> UpdateById(Guid id, CategoryDto category);
    Task<PagedResponse<CategoryDto>> LoadAll(int page, int pageSize, string sortOrder);
}
