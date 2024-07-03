namespace Kitchen.Application.DTOs
{
    public class FindCategoriesResponseDto
    {
        public List<CategoryDto> Categories { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
    }
}
