namespace Kitchen.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<MenuSelections> MenuSelections { get; set; } = [];
        public Category() { }
        public Category(string name)
        {
            Name = name;
        }
    }
}
