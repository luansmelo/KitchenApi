using Kitchen.Application.DTOs.Group;
using Kitchen.Domain.Entities;

namespace Kitchen.Application.Contracts.UseCases
{
    public interface IGroupUseCase
    {
        Task AddGroup(GroupDto group);
        Task<Group> GetById(Guid id);
        Task DeleteById(Guid id);
        Task UpdateById(Guid id, Group group);
        Task<FindGroupsResponse> LoadAll(int page, int pageSize, string sortOrder);
    }
}
