using Kitchen.Application.UseCases;
using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Entities;
using Kitchen.Models.Category;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers
{
    [Route("api/v1/measurement")]
    [ApiController]
    public class MeasurementController(IMeasurementUseCase measurementUseCase) : ControllerBase
    {
        private readonly IMeasurementUseCase _measurementUseCase = measurementUseCase;

        [HttpPost]
        public async Task<IActionResult> Add(MeasurementInput input)
        {
            try
            {
                var measurement = new Measurement(input.Name);

                await _measurementUseCase.AddMeasurement(measurement);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
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
    }
}
