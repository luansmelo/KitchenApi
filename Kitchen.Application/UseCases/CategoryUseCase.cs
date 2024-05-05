using Kitchen.Domain.Contracts;
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

        public async Task DeleteById(Guid id)
        {
            var category = await GetById(id) ?? throw new Exception("Categoria não encontrada");

            await _categoryRepository.DeleteById(category.Id);
        }

        public async Task<Category> GetById(Guid id)
        {
            var category = await _categoryRepository.GetById(id);

            return category == null ? throw new Exception("Categoria já cadastrada") : category;
        }

        public async Task UpdateById(Guid id, Category category)
        {
            var categoryExist = await GetById(id) ?? throw new Exception("Categoria não encontrada");

            await _categoryRepository.UpdateById(categoryExist.Id, category);
        }
    }
}
