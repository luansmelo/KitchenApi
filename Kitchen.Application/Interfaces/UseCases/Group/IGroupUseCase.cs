using Kitchen.Application.DTOs;
using Kitchen.Application.DTOs.Group;
using Kitchen.Shared.Responses;

namespace Kitchen.Application.Interfaces.UseCases.Group;

public interface IGroupUseCase
{
    Task<GroupDto> AddGroup(GroupDto groupDto);
    Task<GroupDto> GetById(Guid id);
    Task<GroupDto> DeleteById(Guid id);
    Task<GroupDto> UpdateById(Guid id, GroupDto group);
    Task<PagedResponse<GroupDto>> LoadAll(int page, int pageSize, string sortOrder);
}