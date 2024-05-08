using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Entities;
using Kitchen.Infra.KitchenConnectionContext;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly HotelDbContext _hotelDbContext;

        public ProductRepository(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }

        public async Task AddInputToProduct(AddIngredientToProductInput product)
        {
            var productEntity = await GetById(product.ProductId);

            if (productEntity != null)
            {
                foreach (var ingredient in product.Ingredients)
                {
                    var existingIngredient = await _hotelDbContext.Ingredient.FindAsync(ingredient.IngredientId);

                    if (existingIngredient != null)
                    {
                        var inputAddToProduct = new IngredientsOnProduct
                        {
                            ProductId = productEntity.Id,
                            IngredientId = ingredient.IngredientId,
                            Measurement = ingredient.MeasurementName,
                            Grammage = ingredient.Grammage
                        };

                        await _hotelDbContext.IngredientsOnProduct.AddAsync(inputAddToProduct);
                    }                
                }
            }
            await _hotelDbContext.SaveChangesAsync();
        }

        public async Task AddProduct(Product product)
        {
            await _hotelDbContext.Product.AddAsync(product);
            await _hotelDbContext.SaveChangesAsync();
        }

        public async Task DeleteById(Guid id)
        {
            var product = await GetById(id);
            if (product != null)
            {
                _hotelDbContext.Product.Remove(product);
                await _hotelDbContext.SaveChangesAsync();
            }
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _hotelDbContext
                .Product
                .Include(product => product.IngredientsOnProduct)
                .ThenInclude(g => g.Ingredient)
                .ThenInclude(ingredient => ingredient.Measurement)
                .Include(product => product.IngredientsOnProduct)
                .ThenInclude(g => g.Ingredient)
                .ThenInclude(ingredient => ingredient.GroupsOnIngredient)
                .ThenInclude(groupOnIngredient => groupOnIngredient.Group)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Product> GetByName(string name)
        {
            return await _hotelDbContext
                .Product
                .FirstOrDefaultAsync(c => c.Name == name);
        }

        public Task<FindProductResponse> LoadAll(int page, int pageSize, string sortOrder)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveInputToProduct(RemoveInputToProduct product)
        {
            var ingredient = await _hotelDbContext
                .IngredientsOnProduct
                .FirstOrDefaultAsync(i => i.ProductId == product.ProductId && i.IngredientId == product.IngredientId);

            if (ingredient != null)
            {
                _hotelDbContext.IngredientsOnProduct.Remove(ingredient);
                await _hotelDbContext.SaveChangesAsync();
            }
        }

        public Task UpdateById(Guid id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
