using Kitchen.Domain.Contracts.UseCases;

namespace Kitchen.Domain.Contracts
{
    public interface IIngredientUseCase
    {
        Task AddIngredient(IngredientInput ingredient);
        Task<IngredientResponse> GetById(Guid id);
        Task DeleteById(Guid id);
        Task UpdateById(Guid id, IngredientInput ingredient);
        Task<FindIngredientsResponse> LoadAll(int page, int pageSize, string sortOrder);
    }
}
