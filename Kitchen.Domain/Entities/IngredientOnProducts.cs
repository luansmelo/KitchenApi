namespace Kitchen.Domain.Entities
{
    public class IngredientOnProducts : BaseEntity
    {
        public Guid IngredientId { get; set; } = Guid.Empty;
        public Ingredient.Ingredient Ingredient { get; set; } = new Ingredient.Ingredient();
        public Guid ProductId { get; set; } = Guid.Empty;
        public Product Product { get; set; } = new Product();
        public string Measurement { get; set; } = string.Empty;
        public decimal Grammager { get; set; } = decimal.Zero;
    }
}
