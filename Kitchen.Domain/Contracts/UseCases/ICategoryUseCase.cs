using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts.UseCases
{
    public interface ICategoryUseCase
    {
        Task AddCategory(Category category);
        Task<Category> GetById(Guid id);
        Task DeleteById(Guid id);
    }
}
