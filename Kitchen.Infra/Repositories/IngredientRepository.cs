using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Entities;
using Kitchen.Infra.KitchenConnectionContext;
using System.Data.Entity;

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
            throw new NotImplementedException();
        }

        public async Task<Ingredient> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Ingredient> GetByName(string name)
        {
            return await _hotelDbContext
                .Ingredient
                .FirstOrDefaultAsync(x => x.Name == name);                 
        }

        public async Task<FindIngredientsResponse> LoadAll(int page, int pageSize, string sortOrder)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateById(Guid id, Ingredient ingredient)
        {
            throw new NotImplementedException();
        }
    }
}
