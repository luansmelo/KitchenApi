namespace Kitchen.Application.DTOs.Product
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Accession { get; set; } = 0;
        public string Resource { get; set; } = string.Empty;
        public string PreparationTime { get; set; } = string.Empty;
        public string? Photo_url { get; set; } = string.Empty;
    }
}
