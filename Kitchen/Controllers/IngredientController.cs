using Kitchen.Domain.Contracts;
using Kitchen.Domain.Contracts.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers
{
    [Route("api/v1/ingredient")]
    [ApiController]
    public class IngredientController(IIngredientUseCase ingredientUseCase) : ControllerBase
    {   
        private readonly IIngredientUseCase _ingredientUseCase = ingredientUseCase;

        [HttpPost]
        public async Task<IActionResult> Add(IngredientInput input)
        {
            try
            {
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
