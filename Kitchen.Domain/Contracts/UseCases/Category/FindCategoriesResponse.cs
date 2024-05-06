using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts.UseCases
{
    public class Partial<T>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class FindCategoriesResponse
    {
        public List<Partial<Category>> Categories { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
    }
}
