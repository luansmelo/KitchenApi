using FluentValidation;
using Kitchen.Application.Contracts.UseCases;
using Kitchen.Application.DTOs;
using Kitchen.Application.Error;
using Kitchen.Application.UseCases.Menu;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.API.Controllers
{
    [Route("api/v1/menu")]
    [ApiController]
    public class MenuController(IMenuUseCase menuUseCase, IValidator<MenuDto> validator) : ControllerBase
    {
        private readonly IMenuUseCase _menuUseCase = menuUseCase;
        private readonly IValidator<MenuDto> _validator = validator;

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] MenuDto input) { 
            try
            {
                var validation = _validator.Validate(input);

                if (!validation.IsValid)
                {
                    return BadRequest(validation.Errors.ToCustomValidationFailure());
                }

                await _menuUseCase.AddMenu(input);

                return Ok();
            } catch(Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpPost("add/product")]
        public async Task<ActionResult> Add([FromBody] AddProductDto input)
        {
            try
            {
                await _menuUseCase.AddProductToMenu(input);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuResponse>> GetById(Guid id)
        {
            try
            {
                var menu = await _menuUseCase.GetById(id);

                return Ok(menu);
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
                await _menuUseCase.DeleteById(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpGet("{menuId}/category/{categoryId}/weekDay/{weekDay}")]
        public async Task<ActionResult<MenuResponse>> GetMenu([FromRoute] Guid menuId, Guid categoryId, string weekDay)
        {
            try
            {
                var menu = await _menuUseCase.GetByMenu(menuId, categoryId, weekDay);
                
                return Ok(menu);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }
    }
}
