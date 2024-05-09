using FluentValidation;
using Kitchen.Application.Contracts.UseCases;
using Kitchen.Application.DTOs.Category;
using Kitchen.Application.Error;
using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers
{
    [Route("api/v1/category")]
    [ApiController]
    public class CategoryController(ICategoryUseCase categoryUseCase, IValidator<CategoryDto> validator) : ControllerBase
    {
        private readonly ICategoryUseCase _categoryUseCase = categoryUseCase; 
        private readonly IValidator<CategoryDto> _validator = validator;

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategoryDto input)
        {
            try
            {
                var validation = _validator.Validate(input);

                if (!validation.IsValid)
                {
                    return BadRequest(validation.Errors.ToCustomValidationFailure());
                }

                await _categoryUseCase.AddCategory(input);

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
                await _categoryUseCase.DeleteById(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(Guid id, Category category)
        {
            try
            {
                await _categoryUseCase.UpdateById(id, category);
                return Ok();
            } catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<FindCategoriesResponse>> GetAll(int page = 1, int pageSize = 10, string sortOrder = "asc")
        {
            try
            {
                var categories = await _categoryUseCase.LoadAll(page, pageSize, sortOrder);

                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }
    }
}
