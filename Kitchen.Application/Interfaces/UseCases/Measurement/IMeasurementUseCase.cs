using Kitchen.Application.DTOs.Measurement;

namespace Kitchen.Application.Contracts.UseCases
{
    public interface IMeasurementUseCase
    {
        Task<MeasurementDto> AddMeasurement(MeasurementDto measurement);
        Task<MeasurementDto> GetById(Guid id);
        Task<MeasurementDto> DeleteById(Guid id);
        Task<MeasurementDto> UpdateById(Guid id, MeasurementDto measurement);
        Task<FindMeasuresResponseDto> LoadAll(int page, int pageSize, string sortOrder);
    }
}
