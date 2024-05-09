using Kitchen.Application.DTOs.Product;

namespace Kitchen.Application.Contracts.UseCases
{
    public interface IProductUseCase
    {
        Task AddProduct(ProductDto product);
        Task<ProductResponse> GetById(Guid id);
        Task DeleteById(Guid id);
        Task UpdateById(Guid id, UpdateProduct product);
        Task<FindProductResponse> LoadAll(int page, int pageSize, string sortOrder);
        Task AddInputToProduct(AddIngredientToProductInput product);
        Task RemoveInputToProduct(RemoveInputToProduct product);
    }
}
