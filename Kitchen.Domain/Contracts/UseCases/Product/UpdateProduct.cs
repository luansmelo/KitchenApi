namespace Kitchen.Domain.Contracts.UseCases
{
    public class UpdateProduct : ProductInput
    {
        public List<IngredientAddProduct> Ingredients { get; set; } = [];
    }
}
