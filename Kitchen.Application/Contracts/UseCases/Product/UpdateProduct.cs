namespace Kitchen.Application.Contracts.UseCases
{
    public class UpdateProduct : ProductInput
    {
        public List<IngredientAddProduct> Ingredients { get; set; } = [];
    }
}
