namespace Kitchen.Domain.Entities
{
    public class GroupsOnIngredient : BaseEntity
    {
        public Guid IngredientId { get; set; } = Guid.Empty;
        public Ingredient Ingredient { get; set; } = null!;
        public Guid GroupId { get; set; } = Guid.Empty;
        public  Group Group { get; set; } = null!;
    }
}
