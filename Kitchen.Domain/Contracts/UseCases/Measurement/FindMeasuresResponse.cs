using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts.UseCases
{
    public class FindMeasuresResponse
    {
        public List<Partial<Measurement>> Measures { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
    }
}
