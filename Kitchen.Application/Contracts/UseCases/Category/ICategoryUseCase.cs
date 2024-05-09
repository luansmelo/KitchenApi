using Kitchen.Application.DTOs.Category;
using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Entities;

namespace Kitchen.Application.Contracts.UseCases
{
    public interface ICategoryUseCase
    {
        Task AddCategory(CategoryDto category);
        Task<Category> GetById(Guid id);
        Task DeleteById(Guid id);
        Task UpdateById(Guid id, Category category);
        Task<FindCategoriesResponse> LoadAll(int page, int pageSize, string sortOrder);
    }
}
