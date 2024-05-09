namespace Kitchen.Application.Contracts.UseCases
{
    public class IngredientInput
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; } = decimal.Zero;
        public Guid MeasurementId { get; set; } = Guid.Empty;
        public List<Guid> GroupIds { get; set; } = [];

        public IngredientInput(
           string name = "",
           string code = "",
           decimal unitPrice = 0,
           Guid measurementId = default,
           List<Guid>? groupIds = null
        )
        {
            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            MeasurementId = measurementId == default ? Guid.Empty : measurementId;
            GroupIds = groupIds ?? [];
        }
    }
}
