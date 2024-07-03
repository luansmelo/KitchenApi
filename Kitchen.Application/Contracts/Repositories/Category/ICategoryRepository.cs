using Kitchen.Application.DTOs;
using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategory(Category category);
        Task<Category> GetById(Guid id);
        Task<Category> GetByName(string name);
        Task<Category> DeleteById(Guid id);
        Task<Category> UpdateById(Guid id, Category category);
        Task<FindCategoriesResponse> LoadAll(int page, int pageSize, string sortOrder);
    }
}
