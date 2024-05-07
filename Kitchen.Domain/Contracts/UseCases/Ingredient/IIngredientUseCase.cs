using Kitchen.Domain.Entities;
using Kitchen.Models.Ingredient.Validation;

namespace Kitchen.Domain.Contracts.UseCases
{
    public interface IIngredientUseCase
    {
        Task AddIngredient(IngredientInput ingredient);
        Task<Ingredient> GetById(Guid id);
        Task DeleteById(Guid id);
        Task UpdateById(Guid id, Ingredient ingredient);
        Task<FindIngredientsResponse> LoadAll(int page, int pageSize, string sortOrder);
    }
}
