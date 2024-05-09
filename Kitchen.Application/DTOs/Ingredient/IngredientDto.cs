namespace Kitchen.Application.DTOs.Ingredient
{
    public class IngredientDto
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; } = decimal.Zero;
        public Guid MeasurementId { get; set; } = Guid.Empty;
        public List<Guid> GroupIds { get; set; } = [];
    }
}
