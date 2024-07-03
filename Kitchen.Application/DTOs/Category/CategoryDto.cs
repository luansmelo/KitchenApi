using System.Runtime.Serialization;

namespace Kitchen.Application.DTOs
{
    public class CategoryDto
    {
        [IgnoreDataMember]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
    