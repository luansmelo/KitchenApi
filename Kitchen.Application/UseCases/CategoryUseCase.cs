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
            var categoryExists = await _categoryRepository.GetByName(category.Name);

            if (categoryExists != null)
            {
                throw new Exception("Categoria já cadastrada");
            }

            await _categoryRepository.AddCategory(category);
        }

        public async Task<Category> GetById(Guid id)
        {
            var category = await _categoryRepository.GetById(id);

            if (category == null)
            {
                throw new Exception("Categoria já cadastrada");
            }

            return category;
        }
    }
}
