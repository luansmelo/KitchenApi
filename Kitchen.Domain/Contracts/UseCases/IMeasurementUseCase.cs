using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts.UseCases
{
    public interface IMeasurementUseCase
    {
        Task AddMeasurement(Measurement category);
        Task<Measurement> GetById(Guid id);
        Task DeleteById(Guid id);
        Task UpdateById(Guid id, Measurement category);
        Task<FindMeasuresResponse> LoadAll(int page, int pageSize, string sortOrder);
    }
}
