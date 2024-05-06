using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts.UseCases
{
    public interface IGroupUseCase
    {
        Task AddGroup(Group group);
        Task<Group> GetById(Guid id);
        Task DeleteById(Guid id);
        Task UpdateById(Guid id, Group group);
        Task<FindGroupsResponse> LoadAll(int page, int pageSize, string sortOrder);
    }
}
