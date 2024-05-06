
using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts
{
    public interface ICategoryRepository
    {
        Task AddCategory(Category category);
        Task<Category> GetById(Guid id);
        Task<Category> GetByName(string name);
        Task DeleteById(Guid id);
        Task UpdateById(Guid id, Category category);
        Task<FindCategoriesResponse> LoadAll(int page, int pageSize, string sortOrder);
    }
}
