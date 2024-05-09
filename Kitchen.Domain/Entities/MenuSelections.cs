namespace Kitchen.Domain.Entities
{
    public class MenuSelections : BaseEntity
    {
        public string WeekDay { get; set; } = string.Empty;
        public Guid MenuId { get; set; } = Guid.Empty;
        public Guid CategoryId { get; set; } = Guid.Empty;
        public Guid ProductId { get; set; } = Guid.Empty;
        public Menu Menu { get; set; } = null!;
        public Category Category { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
