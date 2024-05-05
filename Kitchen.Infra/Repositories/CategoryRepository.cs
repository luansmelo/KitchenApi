using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Entities;
using Kitchen.Infra.KitchenConnectionContext;

namespace Kitchen.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly HotelDbContext _hotelDbContext;

        public CategoryRepository(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }

        public async Task AddCategory(Category category)
        {
            await _hotelDbContext.Category.AddAsync(category);
            await _hotelDbContext.SaveChangesAsync();
        }
    }
}
