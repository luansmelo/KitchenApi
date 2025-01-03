using Dapper;
using Kitchen.Domain.Entities;
using Kitchen.Domain.Interfaces;
using Kitchen.Infra.Context;
using Kitchen.Infra.Queries;

namespace Kitchen.Infra.Repositories;

public class GroupRepository(IDbContext dbContext) : IGroupRepository
{
    public async Task<Group> AddGroup(Group group)
    {
        var query = GroupQueries.AddGroupQuery;
       
        var parameters = new DynamicParameters();
        parameters.Add("@Name", group.Name);
        
        using var connection = dbContext.Connection();
        
        var result = await connection.QueryAsync<Group>(query, parameters);
        return result.FirstOrDefault();
    }

    public async Task<Group> DeleteById(Group group)
    {
        var query = GroupQueries.DeleteByIdQuery;
        var parameters = new DynamicParameters();
        parameters.Add("@Id", group.Id);
        
        using var connection = dbContext.Connection();
        var result = await connection.QuerySingleOrDefaultAsync<Group>(query, parameters);
        
        return result;
    }

    public async Task<Group?> GetById(Guid id)
    {
        var query = GroupQueries.GetByIdQuery;
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);
        
        using var connection = dbContext.Connection();
        var result = await connection.QueryFirstOrDefaultAsync<Group>(query, parameters);
        
        return result;
    }

    public async Task<List<Group>> GetByIds(List<Guid> groupIds)
    {
        return null!;
    }

    public async Task<Group?> GetByName(string name)
    {
        var query = GroupQueries.GetByNameQuery;
        var parameters = new DynamicParameters();
        parameters.Add("@Name", name);
        
        using var connection = dbContext.Connection();
        var result = await connection.QueryFirstOrDefaultAsync<Group>(query, parameters);
        
        return result;
    }

    public async Task<(IEnumerable<Group> groups, int totalCount)> LoadAll(int pageNumber, int pageSize, string order)
    {   
        var query = GroupQueries.GetAllQuery(order);
        var parameters = new DynamicParameters();
       
        var offset = (pageNumber - 1) * pageSize;
        
        parameters.Add("@PageSize", pageSize);
        parameters.Add("@OffSet", offset);
        
        using var connection = dbContext.Connection();
        var groups = await connection.QueryAsync<Group>(query, parameters);

        var countQuery = GroupQueries.GetCountQuery;
        var totalCount = await connection.ExecuteScalarAsync<int>(countQuery);
        return (groups, totalCount);
    }

    public async Task<Group> UpdateById(Guid id, Group group)
    {
        var query = GroupQueries.UpdateByIdQuery;
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);
        parameters.Add("@Name", group.Name);
        
        using var connection = dbContext.Connection();
        var result = await connection.QuerySingleOrDefaultAsync<Group>(query, parameters);
        return result;
    }
}