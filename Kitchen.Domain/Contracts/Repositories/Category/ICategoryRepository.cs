
using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts.Repositories
{
    public interface ICategoryRepository
    {
        void AddCategory(Category category);
    }
}
