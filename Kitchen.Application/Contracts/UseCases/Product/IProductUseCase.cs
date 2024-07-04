using Kitchen.Application.DTOs.Product;

namespace Kitchen.Application.Contracts.UseCases
{
    public interface IProductUseCase
    {
        Task<ProductDto> AddProduct(ProductDto productDto);
        Task<ProductResponseDto> GetById(Guid id);
        Task<ProductDto> DeleteById(Guid id);
        Task UpdateById(Guid id, UpdateProduct product);
        Task<FindProductsResponseDto> LoadAll(int page, int pageSize, string sortOrder);
        Task AddInputToProduct(AddIngredientToProductInput product);
        Task RemoveInputToProduct(Guid productId, Guid ingredientId);
    }
}
