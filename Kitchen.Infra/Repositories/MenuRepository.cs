using Kitchen.Domain.Entities;
using Kitchen.Domain.Interfaces;

namespace Kitchen.Infra.Repositories;

public class MenuRepository(Context.DbContext dbContext) : IMenuRepository
{
    private readonly Context.DbContext _dbContext = dbContext;

   /* public async Task<Menu> AddMenu(Menu menu)
    {
        await _dbContext.Menu.AddAsync(menu);
        await _dbContext.SaveChangesAsync();
        return menu;
    }

    public async Task<Menu?> GetById(Guid id)
    {
        var menu = await GetMenuWithIncludes()
            .FirstOrDefaultAsync(m => m.Id == id);

        return menu;
    }

    public async Task<Menu?> GetByName(string name)
    {
        return await _dbContext.Menu
            .FirstOrDefaultAsync(m => m.Name == name);
    }

    public async Task<Menu> DeleteById(Menu menu)
    {
        _dbContext.Menu.Remove(menu);
        await _dbContext.SaveChangesAsync();
        return menu;
    }

    public async Task<Menu?> GetByMenu(FindMenuParamDto menuCategoryProduct)
    {
        var menu = await GetMenuWithIncludes()
            .FirstOrDefaultAsync(menu => menu.MenuCategoryProduct
                .Any(ms =>
                    ms.MenuId == menuCategoryProduct.MenuId &&
                    ms.WeekDay == menuCategoryProduct.WeekDay &&
                    ms.CategoryId == menuCategoryProduct.CategoryId
                )
            );

        if (menu is not null)
        {
            menu.MenuCategoryProduct = menu.MenuCategoryProduct
                .Where(ms => ms.WeekDay == menuCategoryProduct.WeekDay)
                .ToList();
        }

        return menu;
    }

    public async Task<MenuCategoryProduct> AddProduct(MenuCategoryProduct menu)
    {
        await _dbContext.MenuCategoryProduct.AddAsync(menu);
        await _dbContext.SaveChangesAsync();
        return menu;
    }

    public IQueryable<Menu> LoadAll()
    {
        return GetMenuWithIncludes().AsQueryable();
    }

    private IQueryable<Menu> GetMenuWithIncludes()
    {
        return _dbContext
            .Menu
                .Include(m => m.MenuCategoryProduct)
                .ThenInclude(ms => ms.Category)
                .Include(m => m.MenuCategoryProduct)
                .ThenInclude(ms => ms.Product)
                .ThenInclude(p => p.IngredientsOnProduct)
                .ThenInclude(pi => pi.Ingredient)
                .ThenInclude(gp => gp.GroupsOnIngredient)
                .ThenInclude(gp => gp.Group);
    } */
}
