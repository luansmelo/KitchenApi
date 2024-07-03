using Kitchen.Application.Contracts.UseCases;
using Kitchen.Application.DTOs;
using Kitchen.Application.DTOs.Product;
using Kitchen.Domain.Contracts;
using Kitchen.Domain.Contracts.UseCases;
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

        public async Task<Category> AddCategory(Category category)
        {
            var categoryCreated = await _hotelDbContext.Category.AddAsync(category);
            await _hotelDbContext.SaveChangesAsync();

            return categoryCreated.Entity ;
        }

        public async Task<Category> DeleteById(Guid id)
        {
            var category = await GetById(id);
            
            if (category != null)
            {
                _hotelDbContext.Category.Remove(category);
                await _hotelDbContext.SaveChangesAsync();
            }

            return category;
        }

        public async Task<Category> GetById(Guid id)
        {
            var category = await _hotelDbContext.Category.FirstOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<Category> GetByName(string name)
        {
            return await _hotelDbContext
                .Category
                .FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<Category> UpdateById(Guid id, Category category)
        {
            var categoryUpdate = await GetById(id);
            if (categoryUpdate != null)
            {    

               categoryUpdate.Name = category.Name;

              _hotelDbContext.Category.Update(categoryUpdate);

              await _hotelDbContext.SaveChangesAsync();
            }

            return categoryUpdate;
        }

        public async Task<FindCategoriesResponse> LoadAll(int page, int pageSize, string sortOrder)
        {
            var query = _hotelDbContext.Category.AsQueryable();

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            query = sortOrder.ToLower() == "desc" ? query
                .OrderByDescending(c => c.Name) 
                : query.OrderBy(c => c.Name);

            var categories = await query
               .Skip((page - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();

            return new FindCategoriesResponse
            {
                Categories = categories.Select(c => new CategoryDto
                { 
                    Id = c.Id,
                    Name = c.Name,
                }).ToList(),
                TotalPages = totalPages,
                TotalItems = totalItems
            };
        }
    }
}
