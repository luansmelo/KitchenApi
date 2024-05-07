using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Models.Ingredient.Validation;
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
    }
}
