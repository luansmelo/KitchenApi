using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Entities;

namespace Kitchen.Application.UseCases
{
    public class CategoryUseCase(ICategoryRepository categoryRepository) : ICategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public async Task AddCategory(Category category)
        {
            await _categoryRepository.AddCategory(category);
        }
    }
}
