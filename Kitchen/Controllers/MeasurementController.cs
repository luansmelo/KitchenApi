using FluentValidation;
using Kitchen.Application.Contracts.UseCases;
using Kitchen.Application.DTOs.Measurement;
using Kitchen.Application.Error;
using Kitchen.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers
{
    [Route("api/v1/measurement")]
    [ApiController]
    public class MeasurementController(IMeasurementUseCase measurementUseCase, IValidator<MeasurementDto> validator) : ControllerBase
    {
        private readonly IMeasurementUseCase _measurementUseCase = measurementUseCase;
        private readonly IValidator<MeasurementDto> _validator = validator;

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MeasurementDto input)
        {
            try
            {
                var validation = _validator.Validate(input);

                if (!validation.IsValid)
                {
                    return BadRequest(validation.Errors.ToCustomValidationFailure());
                }

                await _measurementUseCase.AddMeasurement(input);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Measurement>> GetById(Guid id)
        {
            try
            {
                var measurement = await _measurementUseCase.GetById(id);

                return Ok(measurement);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            try
            {
                await _measurementUseCase.DeleteById(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(Guid id, Measurement measurement)
        {
            try
            {
                await _measurementUseCase.UpdateById(id, measurement);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<FindMeasuresResponse>> GetAll(int page = 1, int pageSize = 10, string sortOrder = "asc")
        {
            try
            {
                var categories = await _measurementUseCase.LoadAll(page, pageSize, sortOrder);

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }
    }
}
