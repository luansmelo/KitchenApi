namespace Kitchen.Domain.Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public ICollection<GroupsOnIngredient> GroupsOnIngredient { get; set; }

        public Group() { }

        public Group(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
