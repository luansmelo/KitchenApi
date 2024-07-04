using Kitchen.Application.DTOs;
using Kitchen.Application.DTOs.Measurement;
using Kitchen.Domain.Entities;

namespace Kitchen.Application.Contracts.UseCases
{
    public class IngredientResponse
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; } = decimal.Zero;
        public decimal? Grammage {  get; set; } = decimal.Zero;
        public MeasurementDto Measurement { get; set; } = null!;
        public List<GroupDto> Groups { get; set; } = null!;
    }
}
