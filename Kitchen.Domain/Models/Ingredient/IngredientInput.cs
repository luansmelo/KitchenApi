namespace Kitchen.Models.Ingredient.Validation
{
    public class IngredientInput
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; } = decimal.Zero;
        public Guid MeasurementId { get; set; } = Guid.Empty;
        public List<Guid> GroupIds { get; set; } = new List<Guid>();
    }
}
