using Kitchen.Domain.Contracts;
using Kitchen.Domain.Entities;
using Kitchen.Infra.KitchenConnectionContext;
using Microsoft.EntityFrameworkCore;

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

        public async Task DeleteById(Guid id)
        {
            var category = await GetById(id);
            
            if (category != null)
            {
                _hotelDbContext.Category.Remove(category);
                await _hotelDbContext.SaveChangesAsync();
            }
        }

        public async Task<Category> GetById(Guid id)
        {
            return await _hotelDbContext
                .Category
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category> GetByName(string name)
        {
            return await _hotelDbContext
                .Category
                .FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task UpdateById(Guid id, Category category)
        {
            var categoryUpdate = await GetById(id);
            if (categoryUpdate != null)
            {    

               categoryUpdate.Name = category.Name;

              _hotelDbContext.Category.Update(categoryUpdate);

              await _hotelDbContext.SaveChangesAsync();
            }
        }
    }
}
