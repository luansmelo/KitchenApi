namespace Kitchen.Domain.Contracts.UseCases
{
    public class FindProductResponse
    {
        public List<ProductResponse> Products { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
    }
}
