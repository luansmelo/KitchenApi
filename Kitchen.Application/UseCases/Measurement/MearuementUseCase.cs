using Kitchen.Domain.Contracts;
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

        public async Task<FindMeasuresResponse> LoadAll(int page, int pageSize, string sortOrder)
        {
            return await _measurementRepository.LoadAll(page, pageSize, sortOrder);
        }

        public async Task<Measurement> GetById(Guid id)
        {
            return await _measurementRepository.GetById(id) 
                ?? throw new Exception("Unidade não encontrada");
        }

        public async Task UpdateById(Guid id, Measurement category)
        {
            var measurementExist = await GetById(id);

            await _measurementRepository.UpdateById(measurementExist.Id, category);
        }
    }
}
