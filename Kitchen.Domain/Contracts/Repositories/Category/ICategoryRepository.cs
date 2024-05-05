
using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts.Repositories
{
    public interface ICategoryRepository
    {
        Task AddCategory(Category category);
        Task<Category> GetById(Guid id);
        Task<Category> GetByName(string name);
        Task DeleteById(Guid id);
        Task UpdateById(Guid id, Category category);
    }
}
