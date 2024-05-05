using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Entities;
using Kitchen.Models.Category;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers
{
    [Route("api/v1/category")]
    [ApiController]
    public class CategoryController(ICategoryUseCase categoryUseCase) : ControllerBase
    {
        private readonly ICategoryUseCase _categoryUseCase = categoryUseCase;

        [HttpPost]
        public async Task<IActionResult> Add(CategoryInput input)
        {
            try
            {
                var category = new Category(input.Name);

                await _categoryUseCase.AddCategory(category);

                return Ok();
            } catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetById(Guid id)
        {
            try
            {
                var category = await _categoryUseCase.GetById(id);

                return Ok(category);
            } catch(Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }
    }
}
