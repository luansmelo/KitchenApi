namespace Kitchen.Domain.Contracts.UseCases
{
    public class GroupResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class IngredientResponse
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; } = decimal.Zero;
        public Guid MeasurementId { get; set; }
        public List<GroupResponse> Groups { get; set; }
    }
}
