using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts.UseCases
{
    public interface ICategoryUseCase
    {
        public Task AddCategory(Category category);
    }
}
