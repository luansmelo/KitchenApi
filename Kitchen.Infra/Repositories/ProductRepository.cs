using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Contracts.UseCases.Product;
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
                
                foreach (var ingredient in product.Ingredient)
                {
                    var inputAddToProduct = new IngredientOnProducts
                    {
                        IngredientId = ingredient.IngredientId,
                        Measurement = ingredient.MeasurementName,
                        Grammage = ingredient.Grammage
                    };

                    await _hotelDbContext.IngredientOnProducts.AddAsync(inputAddToProduct);
                    
                }

                await _hotelDbContext.SaveChangesAsync();
            }
        }

        public async Task AddProduct(Product product)
        {
            await _hotelDbContext.Product.AddAsync(product);
            await _hotelDbContext.SaveChangesAsync();
        }

        public Task DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _hotelDbContext
                .Product
                .Include(product => product.IngredientOnProducts)
                .ThenInclude(g => g.Ingredient)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Product> GetByName(string name)
        {
            return await _hotelDbContext
                .Product
                .Include(product => product.IngredientOnProducts)
                .ThenInclude(g => g.Ingredient)
                .FirstOrDefaultAsync(c => c.Name == name);
        }

        public Task<FindProductResponse> LoadAll(int page, int pageSize, string sortOrder)
        {
            throw new NotImplementedException();
        }

        public Task RemoveInputToProduct()
        {
            throw new NotImplementedException();
        }

        public Task UpdateById(Guid id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
