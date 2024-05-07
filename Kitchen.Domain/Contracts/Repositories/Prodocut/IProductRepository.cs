using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts.Repositories
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
        Task<Product> GetById(Guid id);
        Task<Product> GetByName(string name);
        Task DeleteById(Guid id);
        Task UpdateById(Guid id, Product product);
        Task<FindProductResponse> LoadAll(int page, int pageSize, string sortOrder);
        Task AddInputToProduct();
        Task RemoveInputToProduct();
    }
}
