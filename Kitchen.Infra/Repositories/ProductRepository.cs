using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Entities;
using Kitchen.Infra.KitchenConnectionContext;

namespace Kitchen.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly HotelDbContext _hotelDbContext;

        public ProductRepository(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }

        public Task AddInputToProduct()
        {
            throw new NotImplementedException();
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

        public Task<Product> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<FindProductResponse> LoadAll(int page, int pageSize, string sortOrder)
        {
            throw new NotImplementedException();
        }

        public Task RemoveInputToProduct()
        {
            throw new NotImplementedException();
        }

        public Task UpdateById(Guid id, Product category)
        {
            throw new NotImplementedException();
        }
    }
}
