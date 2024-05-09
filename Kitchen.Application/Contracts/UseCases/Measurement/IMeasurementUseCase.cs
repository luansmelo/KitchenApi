using Kitchen.Application.DTOs.Measurement;
using Kitchen.Domain.Entities;

namespace Kitchen.Application.Contracts.UseCases
{
    public interface IMeasurementUseCase
    {
        Task AddMeasurement(MeasurementDto measurement);
        Task<Measurement> GetById(Guid id);
        Task DeleteById(Guid id);
        Task UpdateById(Guid id, Measurement measurement);
        Task<FindMeasuresResponse> LoadAll(int page, int pageSize, string sortOrder);
    }
}
