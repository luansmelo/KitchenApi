using Kitchen.Application.DTOs.Ingredient;

namespace Kitchen.Application.Contracts.UseCases
{
    public interface IIngredientUseCase
    {
        Task AddIngredient(IngredientDto ingredient);
        Task<IngredientResponse> GetById(Guid id);
        Task DeleteById(Guid id);
        Task UpdateById(Guid id, IngredientInput ingredient);
        Task<FindIngredientsResponse> LoadAll(int page, int pageSize, string sortOrder);
    }
}
