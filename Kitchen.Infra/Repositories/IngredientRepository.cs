using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Entities;
using Kitchen.Infra.KitchenConnectionContext;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infra.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly HotelDbContext _hotelDbContext;

        public IngredientRepository(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }

        public async Task AddIngredient(Ingredient ingredient)
        {
            await _hotelDbContext.Ingredient.AddAsync(ingredient);
            await _hotelDbContext.SaveChangesAsync();
        }

        public async Task DeleteById(Guid id)
        {
            var ingredient = await GetById(id);

            if (ingredient != null)
            {
                _hotelDbContext.Ingredient.Remove(ingredient);
                await _hotelDbContext.SaveChangesAsync();
            }
        }

        public async Task<Ingredient> GetById(Guid id)
        {
            return await _hotelDbContext
               .Ingredient
               .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Ingredient> GetByName(string name)
        {
            return await _hotelDbContext
                .Ingredient
                .FirstOrDefaultAsync(x => x.Name == name);                 
        }

        public async Task<FindIngredientsResponse> LoadAll(int page, int pageSize, string sortOrder)
        {
            var query = _hotelDbContext.Ingredient.AsQueryable();

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            query = sortOrder.ToLower() == "desc" ? query
                .OrderByDescending(c => c.Name)
                : query.OrderBy(c => c.Name);

            var ingredients = await query
               .Skip((page - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();

            return new FindIngredientsResponse
            {
                Ingredients = ingredients.Select(c => new Partial<Ingredient> { Id = c.Id, Name = c.Name }).ToList(),
                TotalPages = totalPages,
                TotalItems = totalItems
            };
        }

        public async Task UpdateById(Guid id, Ingredient ingredient)
        {
            var ingredientUpdate = await GetById(id);
            if (ingredientUpdate != null)
            {

                ingredientUpdate.Name = ingredient.Name;
                ingredientUpdate.UnitPrice = ingredient.UnitPrice;
                ingredientUpdate.Code = ingredient.Code;
                ingredientUpdate.MeasurementId = ingredient.MeasurementId;
                ingredientUpdate.GroupsOnIngredient = ingredient.GroupsOnIngredient;

                _hotelDbContext.Ingredient.Update(ingredientUpdate);

                await _hotelDbContext.SaveChangesAsync();
            }
        }
    }
}
