namespace Kitchen.Domain.Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<GroupsOnIngredient> GroupsOnIngredient { get; set; }

        public Group(string name)
        {
            Name = name;
        }
    }
}
