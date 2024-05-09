using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Entities;
using Kitchen.Infra.KitchenConnectionContext;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infra.Repositories
{
    public class MenuRepository(HotelDbContext hotelDbContext) : IMenuRepository
    {
        private readonly HotelDbContext _hotelDbContext = hotelDbContext;
        public async Task AddMenu(Menu menu)
        {
            await _hotelDbContext.Menu.AddAsync(menu);
            await _hotelDbContext.SaveChangesAsync();
        }

        public async Task<Menu> GetById(Guid id)
        {
            var menu = await _hotelDbContext
                .Menu
                .Include(c => c.MenuSelections)
                .FirstOrDefaultAsync(m => m.Id == id);
            return menu;
        }

        public async Task<Menu> GetByName(string name)
        {
            var menu = await _hotelDbContext.Menu
                .FirstOrDefaultAsync(m => m.Name == name);
            return menu;
        }

        public async Task DeleteById(Guid id)
        {
            var menu = await GetById(id);

            if (menu != null)
            {
                _hotelDbContext.Menu.Remove(menu);
                await _hotelDbContext.SaveChangesAsync();
            }
        }

        public async Task<Menu> GetByMenu(MenuSelections menuSelections)
        {
            return await _hotelDbContext.Menu
                .Include(menu => menu.MenuSelections)
                .ThenInclude(ms => ms.Category)
                .Include(menu => menu.MenuSelections)
                .ThenInclude(ms => ms.Product)
                .FirstOrDefaultAsync(menu => menu.MenuSelections.Any(ms =>
                    ms.WeekDay == menuSelections.WeekDay &&
                    ms.CategoryId == menuSelections.CategoryId &&
                    ms.ProductId == menuSelections.ProductId
                ));
        }

        public async Task AddProduct(MenuSelections menu)
        {
            await _hotelDbContext.MenuSelections.AddAsync(menu);
            await _hotelDbContext.SaveChangesAsync();
        }
    }
}
