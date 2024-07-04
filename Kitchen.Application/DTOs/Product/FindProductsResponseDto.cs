using Kitchen.Application.Contracts.UseCases;

namespace Kitchen.Application.DTOs.Product
{
    public class FindProductsResponseDto
    {
        public List<ProductResponse> Products { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
    }
}
