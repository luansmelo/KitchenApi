using Kitchen.Application.Contracts.UseCases;
using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts.Repositories
{
    public interface IProductRepository
    {
        Task<Product> AddProduct(Product product);
        Task<Product> GetById(Guid id);
        Task<Product> GetByName(string name);
        Task<Product> DeleteById(Product product);
        Task UpdateById(Guid id, UpdateProduct product);
        Task<FindProductsResponse> LoadAll(int page, int pageSize, string sortOrder);
        Task AddInputToProduct(AddIngredientToProductInput product);
        Task RemoveInputToProduct(Guid productId, Guid ingredientId);
    }
}
