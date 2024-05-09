namespace Kitchen.Domain.Entities
{
    public class IngredientsOnProduct : BaseEntity
    {
        public Guid IngredientId { get; set; } = Guid.Empty;
        public Ingredient Ingredient { get; set; } = null!;
        public Guid ProductId { get; set; } = Guid.Empty;
        public Product Product { get; set; } = null!;
        public string Measurement { get; set; } = string.Empty;
        public decimal Grammage { get; set; } = decimal.Zero;
    }
}
