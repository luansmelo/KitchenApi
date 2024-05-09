namespace Kitchen.Domain.Entities
{
    public class MenuSelections
    {
        public string WeekDay { get; set; } = string.Empty;
        public string MenuId { get; set; } = string.Empty;
        public string CategoryId { get; set; } = string.Empty;
        public string ProductId { get; set; } = string.Empty;
        public Menu Menu { get; set; } = new();
        public Category Category { get; set; } = new();
        public Product Product { get; set; } = new();
    }
}
