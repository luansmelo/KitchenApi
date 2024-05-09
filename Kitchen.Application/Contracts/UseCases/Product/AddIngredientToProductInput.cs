namespace Kitchen.Application.Contracts.UseCases
{
    public class IngredientAddProduct
    {
        public Guid IngredientId { get; set; }
        public string MeasurementName { get; set; } = string.Empty;
        public decimal Grammage { get; set; } = 0;
    }
    public class AddIngredientToProductInput
    {
        public Guid ProductId { get; set; } = Guid.Empty;
        public List<IngredientAddProduct> Ingredients { get; set; } = [];
    }
}
