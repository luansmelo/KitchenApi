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

        public void AddCategory(Category category)
        {
            _hotelDbContext.Category.Add(category);
            _hotelDbContext.SaveChanges();
        }
    }
}
