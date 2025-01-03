using AutoMapper;
using Kitchen.Application.DTOs.Category;
using Kitchen.Application.Interfaces.UseCases.Category;
using Kitchen.Domain.Interfaces;
using Kitchen.Shared.Responses;
using Kitchen.Domain.Entities;

namespace Kitchen.Application.UseCases;

public class CategoryUseCase(ICategoryRepository categoryRepository, IMapper mapper) : ICategoryUseCase
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<CategoryResponseDto> AddCategory(CategoryDto category)
    {
        var categoryExists = await _categoryRepository.GetByName(category.Name);

        if (categoryExists != null)
        {
            throw new Exception("Categoria já cadastrada");
        }

        var categoryMapper = _mapper.Map<Domain.Entities.Category>(category);

        var createdCategory = await _categoryRepository.AddCategory(categoryMapper);

        return _mapper.Map<CategoryResponseDto>(createdCategory);
    }

    public async Task<CategoryResponseDto> DeleteById(Guid id)
    {
        var category = await _categoryRepository.GetById(id)
                       ?? throw new Exception("Categoria não encontrada");

        var categoryRemoved = await _categoryRepository.DeleteById(category);

        return _mapper.Map<CategoryResponseDto>(categoryRemoved);
    }

    public async Task<CategoryResponseDto> GetById(Guid id)
    {
        var category = await _categoryRepository.GetById(id)
                       ?? throw new Exception("Categoria não encontrada");

        return _mapper.Map<CategoryResponseDto>(category);
    }

    public async Task<PagedResponse<CategoryResponseDto>> LoadAll(int page, int pageSize, string sortOrder)
    {
        var categories = await _categoryRepository.LoadAll(page, pageSize, sortOrder);
        return null!;
    }

    public async Task<CategoryResponseDto> UpdateById(Guid id, CategoryDto category)
    { 
        var categoryExist = await _categoryRepository.GetById(id)
                            ?? throw new Exception("Categoria não encontrada");

        var categoryMapper = _mapper.Map<Category>(categoryExist);
        var categoryUpdated = await _categoryRepository.UpdateById(categoryExist.Id, categoryMapper);

        return _mapper.Map<CategoryResponseDto>(categoryUpdated);
    }
}