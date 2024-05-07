using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts.UseCases
{
    public interface IProductUseCase
    {
        Task AddProduct(ProductInput product);
        Task<Product> GetById(Guid id);
        Task<Product> GetByName(string name);
        Task DeleteById(Guid id);
        Task UpdateById(Guid id, ProductInput product);
        Task<FindProductResponse> LoadAll(int page, int pageSize, string sortOrder);
        Task AddInputToProduct();
        Task RemoveInputToProduct();
    }
}
