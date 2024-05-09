using Kitchen.Application.Contracts.UseCases;
using Kitchen.Application.DTOs.Category;
using Kitchen.Domain.Contracts;
using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Entities;

namespace Kitchen.Application.UseCases
{
    public class CategoryUseCase(ICategoryRepository categoryRepository) : ICategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;

        public async Task AddCategory(CategoryDto category)
        {
            var categoryExists = await _categoryRepository.GetByName(category.Name);

            if (categoryExists != null)
            {
                throw new Exception("Categoria já cadastrada");
            }

            var categoryEntity = new Category(category.Name);

            await _categoryRepository.AddCategory(categoryEntity);
        }

        public async Task DeleteById(Guid id)
        {
            var category = await GetById(id);

            await _categoryRepository.DeleteById(category.Id);
        }

        public async Task<Category> GetById(Guid id)
        {
            return await _categoryRepository.GetById(id) 
                ?? throw new Exception("Categoria não encontrada");
        }

        public async Task<FindCategoriesResponse> LoadAll(int page, int pageSize, string sortOrder)
        {
            return await _categoryRepository.LoadAll(page, pageSize, sortOrder);
        }

        public async Task UpdateById(Guid id, Category category)
        {
            var categoryExist = await GetById(id);

            await _categoryRepository.UpdateById(categoryExist.Id, category);
        }
    }
}
