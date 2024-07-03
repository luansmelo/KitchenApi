using Kitchen.Application.DTOs;

namespace Kitchen.Application.Contracts.UseCases
{
    public interface IGroupUseCase
    {
        Task<GroupDto> AddGroup(GroupDto groupDto);
        Task<GroupDto> GetById(Guid id);
        Task<GroupDto> DeleteById(Guid id);
        Task<GroupDto> UpdateById(Guid id, GroupDto group);
        Task<FindGroupsResponseDto> LoadAll(int page, int pageSize, string sortOrder);
    }
}
