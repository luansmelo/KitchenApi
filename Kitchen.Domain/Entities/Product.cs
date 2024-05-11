using Kitchen.Domain.Enums;

namespace Kitchen.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Accession { get; set; } = 0;
        public string Resource { get; set; } = string.Empty;
        public string PreparationTime { get; set; } = string.Empty;
        public string? Photo_url { get; set; } = string.Empty;
        public Status Status {  get; set; } = Status.Incomplete;
        public ICollection<IngredientsOnProduct> IngredientsOnProduct { get; set; } = [];
        public ICollection<MenuSelections> MenuSelections { get; set; } = [];
    }
}
