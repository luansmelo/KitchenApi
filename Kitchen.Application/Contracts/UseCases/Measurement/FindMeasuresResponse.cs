using Kitchen.Domain.Entities;

namespace Kitchen.Application.Contracts.UseCases
{
    public class FindMeasuresResponse
    {
        public List<Measurement> Measures { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
    }
}
