namespace Kitchen.Application.Models
{
    public class IngredientInput
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; } = decimal.Zero;
        public string MeasurementId { get; set; }
        public List<string> GroupIds { get; set; }
    }
}
