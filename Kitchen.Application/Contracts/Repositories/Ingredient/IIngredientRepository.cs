using Kitchen.Application.Contracts.UseCases;
using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts.Repositories
{
    public interface IIngredientRepository
    {
        Task AddIngredient(Ingredient ingredient);
        Task<Ingredient> GetById(Guid id);
        Task<Ingredient> GetByName(string name);
        Task DeleteById(Guid id);
        Task UpdateById(Guid id, IngredientInput ingredient);
        Task<FindIngredientsResponse> LoadAll(int page, int pageSize, string sortOrder);
    }
}
