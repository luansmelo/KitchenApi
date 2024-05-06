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

    }
}
