using Dapper;
using Kitchen.Domain.Entities;
using Kitchen.Domain.Interfaces;
using Kitchen.Infra.Context;
using Kitchen.Infra.Queries;

namespace Kitchen.Infra.Repositories;

public class MeasurementRepository(IDbContext dbContext) : IMeasurementRepository
{
    public async Task<Measurement> AddMeasurement(Measurement measurement)
    {
        var query = MeasurementQueries.AddMeasurementQuery;
        var parameters = new DynamicParameters();
        parameters.Add("@Name", measurement.Name);
        
        using var connection = dbContext.Connection();
        var result = await connection.QueryAsync<Measurement>(query, parameters);
        
        return result.SingleOrDefault();
    }

    public async Task<Measurement> DeleteById(Measurement measurement)
    {
        var query = MeasurementQueries.DeleteByIdQuery;
        var parameters = new DynamicParameters();
        parameters.Add("@Id", measurement.Id);
        
        using var connection = dbContext.Connection();
        var result = await connection.QueryAsync<Measurement>(query, parameters);
        
        return result.SingleOrDefault();
    }

    public async Task<Measurement?> GetById(Guid id)
    {
        var query = MeasurementQueries.GetByIdQuery;
        var parameters = new DynamicParameters();
        
        parameters.Add("@Id", id);
        
        using var connection = dbContext.Connection();
        var result = await connection.QueryAsync<Measurement>(query, parameters);
        
        return result.SingleOrDefault();
    }

    public async Task<Measurement?> GetByName(string name)
    {
        var query = MeasurementQueries.GetByNameQuery;
        var parameters = new DynamicParameters();
        
        parameters.Add("@Name", name);
        
        using var connection = dbContext.Connection();
        var result = await connection.QueryAsync<Measurement>(query, parameters);
        return result.SingleOrDefault();
    }

    public async Task<Measurement> UpdateById(Guid id, Measurement measurement)
    {
        var query = MeasurementQueries.UpdateByIdQuery;
        var parameters = new DynamicParameters();
        
        parameters.Add("@Id", id);
        parameters.Add("@Name", measurement.Name);
        
        using var connection = dbContext.Connection();
        var result = await connection.QueryAsync<Measurement>(query, parameters);
        return result.SingleOrDefault();
    }

    public async Task<(IEnumerable<Measurement> measurements, int totalCount)> LoadAll(int pageNumber, int pageSize, string order)
    {
        var query = MeasurementQueries.GetAllQuery(order);
        var parameters = new DynamicParameters();
       
        var offset = (pageNumber - 1) * pageSize;
        
        parameters.Add("@PageSize", pageSize);
        parameters.Add("@OffSet", offset);
        
        using var connection = dbContext.Connection();
        var measurements = await connection.QueryAsync<Measurement>(query, parameters);

        var countQuery = MeasurementQueries.GetCountQuery;
        var totalCount = await connection.ExecuteScalarAsync<int>(countQuery);
        return (measurements, totalCount);
    }
}
