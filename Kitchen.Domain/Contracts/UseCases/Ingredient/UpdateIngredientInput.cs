namespace Kitchen.Domain.Contracts.UseCases
{
    public class UpdateIngredientInput
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public decimal? UnitPrice { get; set; }
        public Guid? MeasurementId { get; set; }
        public List<Guid>? GroupIds { get; set; }
    }
}
