using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Entities;
using Kitchen.Infra.KitchenConnectionContext;

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
    }
}
