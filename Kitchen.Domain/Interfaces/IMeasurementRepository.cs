using Kitchen.Application.Contracts.UseCases;
using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts.Repositories
{
    public interface IMeasurementRepository
    {
        Task<Measurement> AddMeasurement(Measurement measurement);
        Task<Measurement?> GetById(Guid id);
        Task<Measurement?> GetByName(string name);
        Task<Measurement> DeleteById(Measurement measurement);
        Task<Measurement> UpdateById(Measurement measurement);
        Task<FindMeasuresResponse> LoadAll(int page, int pageSize, string sortOrder);
    }
}
