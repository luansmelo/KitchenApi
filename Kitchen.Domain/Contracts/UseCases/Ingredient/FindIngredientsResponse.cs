using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts.UseCases
{
    public class FindIngredientsResponse
    {
        public required List<Partial<Ingredient>> Ingredients { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
    }

}
