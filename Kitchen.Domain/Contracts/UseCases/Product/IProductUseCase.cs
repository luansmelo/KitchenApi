using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Contracts.UseCases.Product;

namespace Kitchen.Domain.Contracts.UseCases
{
    public interface IProductUseCase
    {
        Task AddProduct(ProductInput product);
        Task<ProductResponse> GetById(Guid id);
        Task<ProductResponse> GetByName(string name);
        Task DeleteById(Guid id);
        Task UpdateById(Guid id, ProductInput product);
        Task<FindProductResponse> LoadAll(int page, int pageSize, string sortOrder);
        Task AddInputToProduct(AddIngredientToProductInput product);
        Task RemoveInputToProduct();
    }
}
