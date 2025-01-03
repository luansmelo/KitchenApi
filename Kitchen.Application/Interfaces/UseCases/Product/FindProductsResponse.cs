namespace Kitchen.Application.Contracts.UseCases;

public class FindProductsResponse
{
    public List<ProductResponse>? Products { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
}
