using AutoMapper;
using Kitchen.Application.DTOs.Measurement;
using Kitchen.Application.Interfaces.UseCases.Measurement;
using Kitchen.Domain.Entities;
using Kitchen.Domain.Interfaces;
using Kitchen.Domain.Pagination;

namespace Kitchen.Application.UseCases;

public class MeasurementUseCase(IMeasurementRepository measurementRepository, IMapper mapper) : IMeasurementUseCase
{
    private readonly IMeasurementRepository _measurementRepository = measurementRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<MeasurementResponse> AddMeasurement(MeasurementDto measurement)
    {
       /* var measurementExists = await _measurementRepository.GetByName(measurement.Name);

        if (measurementExists != null)
        {
            throw new Exception("Unidade já cadastrada");
        }

        var measurementMapper = _mapper.Map<Measurement>(measurement);

        var measurementCreated = await _measurementRepository.AddMeasurement(measurementMapper);

        return _mapper.Map<MeasurementResponse>(measurementCreated);*/
       return null!;
    }

    public async Task<MeasurementResponse> DeleteById(Guid id)
    {
    /*    var measurement = await GetById(id) ?? throw new Exception("Unidade não encontrada");

        var measureMapper = _mapper.Map<Measurement>(measurement);

        var measurementDeleted = await _measurementRepository.DeleteById(measureMapper);

        return _mapper.Map<MeasurementResponse>(measurementDeleted);*
        */
    return null!;
    }

    public async Task<PagedList<MeasurementResponse>> LoadAll(int pageNumber, int pageSize, string sortOrder)
    {
     /*   var measures = await _measurementRepository.LoadAll(pageNumber, pageSize, sortOrder);
        
        var measureResponse =  _mapper.Map<ICollection<MeasurementResponse>>(measures);
        return new PagedList<MeasurementResponse>(measureResponse, pageNumber, pageSize, measures.TotalCount);
        */
        return null!;
    }

    public async Task<MeasurementResponse> GetById(Guid id)
    {
        /*var measure = await _measurementRepository.GetById(id) 
                      ?? throw new Exception("Unidade não encontrada");

        return _mapper.Map<MeasurementResponse>(measure);*/
        return null!;
    }

    public async Task<MeasurementResponse> UpdateById(Guid id, MeasurementDto measureDto)
    {
        /*await GetById(id);

        var measureMapper = _mapper.Map<Measurement>(measureDto);
        var measure = await _measurementRepository.UpdateById(measureMapper);

        return _mapper.Map<MeasurementResponse>(measure);*/
        return null!;
    }
}