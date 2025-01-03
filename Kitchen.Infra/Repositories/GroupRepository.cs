using Kitchen.Domain.Entities;
using Kitchen.Domain.Interfaces;
using Kitchen.Domain.Pagination;
using Kitchen.Infra.Context;

namespace Kitchen.Infra.Repositories;

public class GroupRepository(Context.DbContext dbContext) : IGroupRepository
{
    private readonly Context.DbContext _dbContext = dbContext;

    public async Task<Group> AddGroup(Group group)
    {
        return group;
    }

    public async Task<Group> DeleteById(Group group)
    {
        return group;
    }

    public async Task<Group?> GetById(Guid id)
    {
        return null;
    }

    public async Task<List<Group>> GetByIds(List<Guid> groupIds)
    {
        return null!;
    }

    public async Task<Group?> GetByName(string name)
    {
        return null;
    }

    public async Task<PagedList<Group>> LoadAll(int pageNumber, int pageSize, string sortBy)
    {   
        return null;
    }

    public async Task<Group> UpdateById(Guid id, Group group)
    {
        return null;
    }
}