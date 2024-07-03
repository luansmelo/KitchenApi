using System.Runtime.Serialization;

namespace Kitchen.Application.DTOs
{
    public class GroupDto
    {
        [IgnoreDataMember]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
