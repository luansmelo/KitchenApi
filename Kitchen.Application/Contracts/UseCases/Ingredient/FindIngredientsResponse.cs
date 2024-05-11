namespace Kitchen.Application.Contracts.UseCases
{

    public class FindIngredientsResponse
    {
        public required List<IngredientResponse> Ingredients { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
    }

}
