using Kitchen.Application.Contracts.UseCases;
using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts.Repositories
{
    public interface IGroupRepository
    {
        Task<Group> AddGroup(Group group);
        Task<Group?> GetById(Guid id);
        Task<List<Group>> GetByIds(List<Guid> groupIds);
        Task<Group?> GetByName(string name);
        Task<Group> DeleteById(Group group);
        Task<Group> UpdateById(Group group);
        Task<FindGroupsResponse> LoadAll(int page, int pageSize, string sortOrder);
    }
}
