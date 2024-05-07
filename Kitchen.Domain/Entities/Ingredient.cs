namespace Kitchen.Domain.Entities
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; set; }
        public Guid MeasurementId { get; set; }
        public string Code { get; set; }
        public decimal UnitPrice { get; set; }
        public ICollection<GroupsOnIngredient> GroupsOnIngredient { get; set; }
    }
}
