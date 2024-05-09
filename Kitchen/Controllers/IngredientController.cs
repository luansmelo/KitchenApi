using FluentValidation;
using Kitchen.Application.Contracts.UseCases;
using Kitchen.Application.DTOs.Ingredient;
using Kitchen.Application.Error;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers
{
    [Route("api/v1/ingredient")]
    [ApiController]
    public class IngredientController(IIngredientUseCase ingredientUseCase, IValidator<IngredientDto> validator) : ControllerBase
    {   
        private readonly IIngredientUseCase _ingredientUseCase = ingredientUseCase;
        private readonly IValidator<IngredientDto> _validator = validator;

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] IngredientDto input)
        {
            try
            {
                var validation = _validator.Validate(input);

                if (!validation.IsValid)
                {
                    return BadRequest(validation.Errors.ToCustomValidationFailure());
                }

                await _ingredientUseCase.AddIngredient(input);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IngredientResponse), 200)]
        public async Task<ActionResult<IngredientResponse>> GetById(Guid id)
        {
            try
            {
                var ingredient = await _ingredientUseCase.GetById(id);

                return Ok(ingredient);
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
                await _ingredientUseCase.DeleteById(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(Guid id, IngredientInput ingredient)
        {
            try
            {
                await _ingredientUseCase.UpdateById(id, ingredient);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<FindIngredientsResponse>> GetAll(int page = 1, int pageSize = 10, string sortOrder = "asc")
        {
            try
            {
                var ingredients = await _ingredientUseCase.LoadAll(page, pageSize, sortOrder);

                return Ok(ingredients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }
    }
}
