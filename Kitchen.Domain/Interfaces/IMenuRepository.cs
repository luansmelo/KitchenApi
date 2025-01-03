using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Interfaces.Repositories.Menu;

public interface IMenuRepository
{
    Task<Entities.Menu> AddMenu(Entities.Menu menu);
    Task<Entities.Menu?> GetById(Guid id);
    Task<Entities.Menu?> GetByName(string name);
    Task<Entities.Menu?> GetByMenu(FindMenuParamDto menu);
    Task<Entities.Menu> DeleteById(Entities.Menu menu);
    Task<MenuCategoryProduct> AddProduct(MenuCategoryProduct menu);
    Task<FindMenusResponse> LoadAll(int page, int pageSize, string sortOrder);
}