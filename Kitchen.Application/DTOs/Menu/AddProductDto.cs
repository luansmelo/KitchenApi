namespace Kitchen.Application.DTOs
{
    public class ProductToAdd
    {
        public Guid ProductId { get; set; } = Guid.Empty;
        public List<string> WeekDays { get; set; } = new List<string>();
    }

    public class AddProductDto
    {
        public Guid MenuId { get; set; } = Guid.Empty;
        public Guid CategoryId {  get; set; } = Guid.Empty;
        public List<ProductToAdd> Products { get; set; } = new List<ProductToAdd>();
    }
}
