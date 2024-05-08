using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Contracts.UseCases.Product;
using Kitchen.Domain.Entities;

namespace Kitchen.Application.UseCases
{
    public class ProductUseCase(IProductRepository productRepository) : IProductUseCase
    {

        private readonly IProductRepository _productRepository = productRepository;
        public async Task AddInputToProduct(AddIngredientToProductInput product)
        {
            await GetById(product.ProductId);
            await _productRepository.AddInputToProduct(product);
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

        public async Task DeleteById(Guid id)
        {
            await GetById(id);
            await _productRepository.DeleteById(id);
        }

        public async Task<ProductResponse> GetById(Guid id)
        {
            var product = await _productRepository.GetById(id) 
                ?? throw new Exception("Produto não encontrado");

            var groups = product.IngredientsOnProduct.Select(g => new GroupResponse()
            {
                Id = g.Id,
                Name = g.Measurement,
            }).ToList();

            var ingredients = product.IngredientsOnProduct.Select(i => new IngredientResponse()
            {
                Id = i.Id,
                Name = i.Ingredient.Name,
                Code = i.Ingredient.Code,
                UnitPrice = i.Ingredient.UnitPrice,
                Measurement = i.Ingredient.Measurement,
                Grammage = i.Grammage,
                Groups = groups,
            }).ToList();

            var productResponse = new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Accession = product.Accession,
                PreparationTime = product.PreparationTime,
                Resource = product.Resource,
                Ingredients = ingredients,
            };

            return productResponse;
        }

        public Task<ProductResponse> GetByName(string name)
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
