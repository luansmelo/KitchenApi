using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts.UseCases
{
    public class PartialIngredient<T>
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; } = decimal.Zero;
        public Measurement Measurement { get; set; }
        public List<GroupResponse> Groups { get; set; }
    }

    public class FindIngredientsResponse
    {
        public required List<PartialIngredient<IngredientResponse>> Ingredients { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
    }

}
