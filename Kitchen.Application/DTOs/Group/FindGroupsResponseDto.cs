namespace Kitchen.Application.DTOs
{
    public class FindGroupsResponseDto
    {
        public List<GroupDto> Groups { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
    }
}
