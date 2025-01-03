using Dapper;
using Kitchen.Domain.Entities;
using Kitchen.Domain.Interfaces;
using Kitchen.Domain.Pagination;
using Kitchen.Infra.Context;
using Kitchen.Infra.Queries;

namespace Kitchen.Infra.Repositories;

public class CategoryRepository(IDbContext dbContext) : ICategoryRepository
{
    public async Task<Category> AddCategory(Category category)
    {
        var query = CategoryQueries.AddCategoryQuery; 
        
        var parameters = new DynamicParameters();
        parameters.Add("@Name", category.Name);
        
        using var connection = dbContext.Connection();
       
        var result = await connection.QueryAsync<Category>(query, parameters);
        return result.FirstOrDefault();
    }

    public async Task<Category> DeleteById(Guid id)
    {
        var query = CategoryQueries.DeleteByIdQuery;
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);
        
        using var connection = dbContext.Connection();
        
        var result = await connection.QueryFirstOrDefaultAsync<Category>(query, parameters);
        return result;
    }

    public async Task<Category?> GetById(Guid id)
    {
        var query = CategoryQueries.GetByIdQuery;
        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);
        
        using var connection = dbContext.Connection();
        
        var result = await connection.QueryFirstOrDefaultAsync<Category>(query, parameters);
        return result;
    }

    public async Task<Category?> GetByName(string name)
    {   
        var query = CategoryQueries.GetByNameQuery;
        var parameters = new DynamicParameters();
        parameters.Add("@Name", name);
        
        using var connection = dbContext.Connection();
        
        var result = await connection.QueryFirstOrDefaultAsync<Category>(query, parameters);
        return result;
    }

    public async Task<Category> UpdateById(Guid id, Category category)
    {
        var query = CategoryQueries.UpdateByIdQuery;
        var parameters = new DynamicParameters();
        
        parameters.Add("@Id", id);
        
        using var connection = dbContext.Connection();
        
        var result = await connection.QueryFirstOrDefaultAsync<Category>(query, parameters);
        return result;
    }

    public async Task<(IEnumerable<Category> categories, int totalCount)> LoadAll(int pageNumber, int pageSize, string sortBy)
    {
        var query = CategoryQueries.GetAllQuery;
        var parameters = new DynamicParameters();
       
        var offset = (pageNumber - 1) * pageSize;
        
        parameters.Add("@PageSize", pageSize);
        parameters.Add("@OffSet", offset);
        
        using var connection = dbContext.Connection();
        var categories = await connection.QueryAsync<Category>(query, parameters);

        var countQuery = CategoryQueries.GetCountQuery;
        var totalCount = await connection.ExecuteScalarAsync<int>(countQuery);
        return (categories, totalCount);
    }
}
