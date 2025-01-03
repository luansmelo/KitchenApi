using Kitchen.Domain.Entities;
using Kitchen.Domain.Interfaces;

namespace Kitchen.Infra.Repositories;

public class MeasurementRepository(Context.DbContext dbContext) : IMeasurementRepository
{
    private readonly Context.DbContext _dbContext = dbContext;

    public async Task<Measurement> AddMeasurement(Measurement measurement)
    {
        return null;
    }

 /*   public async Task<Measurement> DeleteById(Measurement measurement)
    {
        _dbContext.Measurement.Remove(measurement);
        await _dbContext.SaveChangesAsync();
        return measurement;
    }

    public async Task<Measurement?> GetById(Guid id)
    {
        return await _dbContext
           .Measurement
           .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Measurement?> GetByName(string name)
    {
        return await _dbContext
               .Measurement
               .FirstOrDefaultAsync(c => c.Name == name);
    }

    public async Task<Measurement> UpdateById(Measurement measurement)
    {
        _dbContext.Measurement.Update(measurement);
        await _dbContext.SaveChangesAsync();
        return measurement;
    }

    public async Task<PagedList<Measurement>> LoadAll(int pageNumber, int pageSize, string sortBy)
    {
        var query = _dbContext.Measurement.AsQueryable();
       
        if (!string.IsNullOrEmpty(sortBy))
        {
            query = sortBy.Equals("desc", StringComparison.CurrentCultureIgnoreCase) 
                ? query.OrderByDescending(c => c.Name) 
                : query.OrderBy(c => c.Name);
        }
        
        return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
    }*/
}
