using FluentValidation;
using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Entities;
using Kitchen.Models.Error;
using Kitchen.Models.Group.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers
{
    [Route("api/v1/group")]
    [ApiController]
    public class GroupController(IGroupUseCase groupUseCase, IValidator<GroupInput> validator) : ControllerBase
    {
        private readonly IGroupUseCase _groupUseCase = groupUseCase;
        private readonly IValidator<GroupInput> _validator = validator;

        [HttpPost]
        public async Task<IActionResult> Add(GroupInput input)
        {
            try
            {
                var validation = _validator.Validate(input);

                if (!validation.IsValid)
                {
                    return BadRequest(validation.Errors.ToCustomValidationFailure());
                }

                var group = new Group(input.Name);

                await _groupUseCase.AddGroup(group);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetById(Guid id)
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
                await _groupUseCase.DeleteById(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(Guid id, Group group)
        {
            try
            {
                await _groupUseCase.UpdateById(id, group);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<FindGroupsResponse>> GetAll(int page = 1, int pageSize = 10, string sortOrder = "asc")
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
