namespace Kitchen.Domain.Entities.Ingredient
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public Guid MeasurementId { get; set; }
        public string Code { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public ICollection<GroupsOnIngredient> GroupsOnIngredient { get; set; } = [];
        public ICollection<IngredientOnProducts> IngredientOnProducts { get; set; } = [];
        public Measurement Measurement { get; set; } = new Measurement();
    }
}
