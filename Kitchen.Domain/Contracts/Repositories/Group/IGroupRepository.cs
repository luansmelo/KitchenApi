using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts.Repositories
{
    public interface IGroupRepository
    {
        Task AddGroup(Group group);
        Task<Group> GetById(Guid id);
        Task<List<Group>> GetByIds(List<Guid> groupIds);
        Task<Group> GetByName(string name);
        Task DeleteById(Guid id);
        Task UpdateById(Guid id, Group category);
        Task<FindGroupsResponse> LoadAll(int page, int pageSize, string sortOrder);
    }
}
