using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Entities;
using Kitchen.Infra.KitchenConnectionContext;
using System.Data.Entity;

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
            var menu = await _hotelDbContext.Menu.FirstOrDefaultAsync(m => m.Id == id);
            return menu;
        }

        public async Task<Menu> GetByName(string name)
        {
            var menu = await _hotelDbContext.Menu.FirstOrDefaultAsync(m => m.Name == name);
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
    }
}
