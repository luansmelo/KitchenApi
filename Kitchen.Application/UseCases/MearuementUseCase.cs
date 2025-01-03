using AutoMapper;
using Kitchen.Application.DTOs.Measurement;
using Kitchen.Application.Interfaces.UseCases.Measurement;
using Kitchen.Domain.Interfaces;

namespace Kitchen.Application.UseCases.Measurement;

public class MeasurementUseCase(IMeasurementRepository measurementRepository, IMapper mapper) : IMeasurementUseCase
{
    private readonly IMeasurementRepository _measurementRepository = measurementRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<MeasurementDto> AddMeasurement(MeasurementDto measurement)
    {
        var measurementExists = await _measurementRepository.GetByName(measurement.Name);

        if (measurementExists != null)
        {
            throw new Exception("Unidade já cadastrada");
        }

        var measurementMapper = _mapper.Map<Domain.Entities.Measurement>(measurement);

        var measurementCreated = await _measurementRepository.AddMeasurement(measurementMapper);

        return _mapper.Map<MeasurementDto>(measurementCreated);
    }

    public async Task<MeasurementDto> DeleteById(Guid id)
    {
        var measurement = await GetById(id) ?? throw new Exception("Unidade não encontrada");

        var measureMapper = _mapper.Map<Domain.Entities.Measurement>(measurement);

        var measurementDeleted = await _measurementRepository.DeleteById(measureMapper);

        return _mapper.Map<MeasurementDto>(measurementDeleted);
    }

    /*public async Task<FindMeasuresResponseDto> LoadAll(int page, int pageSize, string sortOrder)
    {
        var measures = await _measurementRepository.LoadAll(page, pageSize, sortOrder);

        return _mapper.Map<FindMeasuresResponseDto>(measures);
    }*/

    public async Task<MeasurementDto> GetById(Guid id)
    {
        var measure = await _measurementRepository.GetById(id) 
                      ?? throw new Exception("Unidade não encontrada");

        return _mapper.Map<MeasurementDto>(measure);
    }

    public async Task<MeasurementDto> UpdateById(Guid id, MeasurementDto measureDto)
    {
        await GetById(id);

        var measureMapper = _mapper.Map<Domain.Entities.Measurement>(measureDto);

        var measure = await _measurementRepository.UpdateById(measureMapper);

        return _mapper.Map<MeasurementDto>(measure);
    }
}