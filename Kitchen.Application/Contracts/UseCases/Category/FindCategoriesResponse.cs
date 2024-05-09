using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts.UseCases
{
    public class FindCategoriesResponse
    {
        public required List<Category> Categories { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
    }
}
