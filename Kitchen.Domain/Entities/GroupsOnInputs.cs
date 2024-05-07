namespace Kitchen.Domain.Entities
{
    public class GroupsOnIngredient : BaseEntity
    {
        public Guid IngredientId { get; set; }
        public Ingredient.Ingredient Ingredient { get; set; }
        public Guid GroupId { get; set; }
        public Group Group { get; set; }
    }
}
