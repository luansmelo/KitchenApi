using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts.Repositories
{
    public interface IMeasurementRepository
    {
        Task AddMeasurement(Measurement measurement);
        Task<Measurement> GetById(Guid id);
        Task<Measurement> GetByName(string name);
        Task DeleteById(Guid id);
        Task UpdateById(Guid id, Measurement measurement);
        Task<FindMeasuresResponse> LoadAll(int page, int pageSize, string sortOrder);
    }
}
