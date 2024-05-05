using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Entities;

namespace Kitchen.Application.UseCases
{
    public class MearuementUseCase(IMeasurementRepository measurementRepository) : IMeasurementUseCase
    {
        private readonly IMeasurementRepository _measurementRepository = measurementRepository;

        public async Task AddMeasurement(Measurement measurement)
        {
            var measurementExists = await _measurementRepository.GetByName(measurement.Name);

            if (measurementExists != null)
            {
                throw new Exception("Unidade já cadastrada");
            }

            await _measurementRepository.AddMeasurement(measurement);
        }

        public async Task DeleteById(Guid id)
        {
            var measurement = await GetById(id) ?? throw new Exception("Unidade não encontrada");

            await _measurementRepository.DeleteById(measurement.Id);
        }

        public async Task<Measurement> GetById(Guid id)
        {
            var measurement = await _measurementRepository.GetById(id);

            return measurement == null ? throw new Exception("Unidade já cadastrada") : measurement;
        }

        public async Task UpdateById(Guid id, Measurement category)
        {
            var measurementExist = await GetById(id) ?? throw new Exception("Unidade não encontrada");

            await _measurementRepository.UpdateById(measurementExist.Id, category);
        }
    }
}
