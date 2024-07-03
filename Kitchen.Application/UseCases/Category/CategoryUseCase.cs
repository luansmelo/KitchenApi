using AutoMapper;
using Kitchen.Application.Contracts.UseCases;
using Kitchen.Application.DTOs;
using Kitchen.Domain.Contracts;
using Kitchen.Domain.Entities;
    
namespace Kitchen.Application.UseCases
{
    public class CategoryUseCase(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<CategoryDto> AddCategory(CategoryDto category)
        {
            var categoryExists = await _categoryRepository.GetByName(category.Name);

            if (categoryExists != null)
            {
                throw new Exception("Categoria já cadastrada");
            }

            var categoryMapper = _mapper.Map<Category>(category);

            var createdCategory = await _categoryRepository.AddCategory(categoryMapper);

            return _mapper.Map<CategoryDto>(createdCategory);
        }

        public async Task<CategoryDto> DeleteById(Guid id)
        {
            var category = await _categoryRepository.GetById(id)
                ?? throw new Exception("Categoria não encontrada");

            var categoryRemoved = await _categoryRepository.DeleteById(category.Id);

            return _mapper.Map<CategoryDto>(categoryRemoved);
        }

        public async Task<CategoryDto> GetById(Guid id)
        {
            var category = await _categoryRepository.GetById(id)
                ?? throw new Exception("Categoria não encontrada");

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<FindCategoriesResponseDto> LoadAll(int page, int pageSize, string sortOrder)
        {
            var categories = await _categoryRepository.LoadAll(page, pageSize, sortOrder);
            return _mapper.Map<FindCategoriesResponseDto>(categories);
        }

        public async Task<CategoryDto> UpdateById(Guid id, CategoryDto category)
        { 
            var categoryExist = await _categoryRepository.GetById(id)
                ?? throw new Exception("Categoria não encontrada");

            var categoryMapper = _mapper.Map<Category>(categoryExist);
            var categoryUpdated = await _categoryRepository.UpdateById(categoryExist.Id, categoryMapper);

            return _mapper.Map<CategoryDto>(categoryUpdated);
        }
    }
}
