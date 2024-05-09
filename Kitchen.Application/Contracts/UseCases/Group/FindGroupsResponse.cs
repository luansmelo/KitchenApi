using Kitchen.Domain.Entities;

namespace Kitchen.Application.Contracts.UseCases
{
    public class FindGroupsResponse
    {
        public List<Group> Groups { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
    }
}
