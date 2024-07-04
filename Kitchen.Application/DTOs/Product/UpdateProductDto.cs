using Kitchen.Application.Contracts.UseCases;
using Kitchen.Domain.Enums;

namespace Kitchen.Application.DTOs.Product
{
    public class UpdateProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Accession { get; set; } = 0;
        public string Resource { get; set; } = string.Empty;
        public string PreparationTime { get; set; } = string.Empty;
        public string? Photo_url { get; set; } = string.Empty;
        public Status Status { get; set; }
        public List<IngredientAddProduct> Ingredients { get; set; } = [];

    }
}
