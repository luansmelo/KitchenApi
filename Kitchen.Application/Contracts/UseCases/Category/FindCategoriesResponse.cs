using Kitchen.Application.DTOs;

namespace Kitchen.Domain.Contracts.UseCases
{
    public class FindCategoriesResponse
    {
        public required List<CategoryDto> Categories { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }

        public FindCategoriesResponse() { }

        public FindCategoriesResponse(List<CategoryDto> categories, int totalPages, int totalItems)
        {
            Categories = categories;
            TotalPages = totalPages;
            TotalItems = totalItems;
        }
    }
}
