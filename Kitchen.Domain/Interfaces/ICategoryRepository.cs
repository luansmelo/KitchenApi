namespace Kitchen.Domain.Interfaces.Category;

public interface ICategoryRepository
{
    Task<Entities.Category> AddCategory(Entities.Category category);
    Task<Entities.Category?> GetById(Guid id);
    Task<Entities.Category?> GetByName(string name);
    Task<Entities.Category> DeleteById(Entities.Category category);
    Task<Entities.Category?> UpdateById(Guid id, Entities.Category category);
    Task<FindCategoriesResponse> LoadAll(int page, int pageSize, string sortOrder);
}