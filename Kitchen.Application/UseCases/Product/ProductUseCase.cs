using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Contracts.UseCases;
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

            var ingredients = product.IngredientsOnProduct.Select(i => new IngredientResponse()
            {
                Id = i.Ingredient.Id,
                Name = i.Ingredient.Name,
                Code = i.Ingredient.Code,
                UnitPrice = i.Ingredient.UnitPrice,
                Measurement = new Measurement()
                {
                    Id = i.Ingredient.Measurement.Id,
                    Name = i.Measurement,
                },
                Grammage = i.Grammage,
                Groups = i.Ingredient.GroupsOnIngredient.Select(g => new GroupResponse()
                {
                    Id = g.Group.Id,
                    Name = g.Group.Name,
                }).ToList(),
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

        public async Task<FindProductResponse> LoadAll(int page, int pageSize, string sortOrder)
        {
            return await _productRepository.LoadAll(page, pageSize, sortOrder);
        }

        public async Task RemoveInputToProduct(RemoveInputToProduct product)
        {
            await GetById(product.ProductId);
            await _productRepository.RemoveInputToProduct(product);
        }

        public async Task UpdateById(Guid id, UpdateProduct product)
        {
            await GetById(id);
            await _productRepository.UpdateById(id, product);
        }
    }
}
