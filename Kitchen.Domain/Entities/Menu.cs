namespace Kitchen.Domain.Entities
{
    public class Menu : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<MenuSelections> MenuSelections { get; set; } = [];
    }
}
