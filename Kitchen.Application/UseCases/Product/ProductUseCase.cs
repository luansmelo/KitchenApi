using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Entities;

namespace Kitchen.Application.UseCases
{
    public class ProductUseCase(IProductRepository productRepository) : IProductUseCase
    {

        private readonly IProductRepository _productRepository = productRepository;
        public Task AddInputToProduct()
        {
            throw new NotImplementedException();
        }

        public async Task AddProduct(ProductInput input)
        {
            var product = new Product()
            {
                Name = input.Name,
                Description = input.Description,
                Accession = input.Accession,
                PreparationTime = input.PreparationTime,
                Resource = input.Resource,
            };

            await _productRepository.AddProduct(product);
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

        public Task UpdateById(Guid id, ProductInput product)
        {
            throw new NotImplementedException();
        }
    }
}
