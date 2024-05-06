using Kitchen.Domain.Entities;
namespace Kitchen.Domain.Contracts.UseCases
{
    public class FindGroupsResponse
    {
        public List<Partial<Group>> Groups { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
    }
}
