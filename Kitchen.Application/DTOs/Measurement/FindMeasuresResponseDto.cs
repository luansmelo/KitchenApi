namespace Kitchen.Application.DTOs.Measurement
{
    public class FindMeasuresResponseDto
    {
        public List<MeasurementDto> Measures { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
    }
}
