using System.Runtime.Serialization;

namespace Kitchen.Application.DTOs.Measurement
{
    public class MeasurementDto
    {
        [IgnoreDataMember]
        public Guid Id {  get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
