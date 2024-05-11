namespace Kitchen.Application.DTOs
{
    public class FindMenuDto
    {
        public string WeekDay { get; set; } = string.Empty;
        public Guid MenuId { get; set; } = Guid.Empty;
        public Guid CategoryId { get; set; } = Guid.Empty;
    }
}
