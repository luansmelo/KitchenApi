using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts.Repositories
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
        Task<Product> GetById(Guid id);
        Task<Product> GetByName(string name);
        Task DeleteById(Guid id);
        Task UpdateById(Guid id, UpdateProduct product);
        Task<FindProductResponse> LoadAll(int page, int pageSize, string sortOrder);
        Task AddInputToProduct(AddIngredientToProductInput product);
        Task RemoveInputToProduct(RemoveInputToProduct product);
    }
}
