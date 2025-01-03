using Kitchen.Domain.Entities;

namespace Kitchen.Application.DTOs.Group;

public class GroupResponseDto : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
}