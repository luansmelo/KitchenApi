using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts.UseCases
{
    public interface ICategoryUseCase
    {
        public void AddCategory(Category category);
    }
}
