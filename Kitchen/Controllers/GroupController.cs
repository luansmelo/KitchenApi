using FluentValidation;
using Kitchen.Application.Contracts.UseCases;
using Kitchen.Application.DTOs;
using Kitchen.Application.Error;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers
{
    [Route("api/v1/group")]
    [ApiController]
    public class GroupController(IGroupUseCase groupUseCase, IValidator<GroupDto> validator) : ControllerBase
    {
        private readonly IGroupUseCase _groupUseCase = groupUseCase;
        private readonly IValidator<GroupDto> _validator = validator;

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] GroupDto input)
        {
            try
            {
                var validation = _validator.Validate(input);

                if (!validation.IsValid)
                {
                    return BadRequest(validation.Errors.ToCustomValidationFailure());
                }

                var group = await _groupUseCase.AddGroup(input);

                return Ok(group);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDto>> GetById(Guid id)
        {
            try
            {
                var group = await _groupUseCase.GetById(id);

                return Ok(group);
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
                var group = await _groupUseCase.DeleteById(id);

                return Ok(group);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(Guid id, GroupDto group)
        {
            try
            {
                var groupUpdated = await _groupUseCase.UpdateById(id, group);
                return Ok(groupUpdated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<FindGroupsResponseDto>> GetAll(int page = 1, int pageSize = 10, string sortOrder = "asc")
        {
            try
            {
                var groups = await _groupUseCase.LoadAll(page, pageSize, sortOrder);

                return Ok(groups);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

    }
}
