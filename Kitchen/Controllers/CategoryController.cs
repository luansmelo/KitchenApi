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
        public IActionResult Add(CategoryInput input)
        {
            try
            {
                var category = new Category(input.Name);

                _categoryUseCase.AddCategory(category);

                return Ok();
            } catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }
    }
}
