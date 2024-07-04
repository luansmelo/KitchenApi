using FluentValidation;
using Kitchen.Application.Contracts.UseCases;
using Kitchen.Application.DTOs.Product;
using Kitchen.Application.Error;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers
{
    [Route("api/v1/product")]
    [ApiController]
    public class ProductController(IProductUseCase productUseCase, IValidator<ProductDto> validator) : ControllerBase
    {   
        private readonly IProductUseCase _productUseCase = productUseCase;
        private readonly IValidator<ProductDto> _validator = validator;

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductDto input)
        {
            try
            {
                var validation = _validator.Validate(input);

                if (!validation.IsValid)
                {
                    return BadRequest(validation.Errors.ToCustomValidationFailure());
                }

                await _productUseCase.AddProduct(input);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpPost("add/ingredient")]
        public async Task<IActionResult> AddInput([FromBody] AddIngredientToProductInput input)
        {
            try
            {
                await _productUseCase.AddInputToProduct(input);

                return Ok();
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
                await _productUseCase.DeleteById(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpDelete("remove/{productId}/ingredient/{ingredientId}")]
        public async Task<IActionResult> DeleteIngredient(Guid productId, Guid ingredientId)
        {
            try
            {
                await _productUseCase.RemoveInputToProduct(productId, ingredientId);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FindProductsResponseDto>> GetById(Guid id)
        {
            try
            {
                var product = await _productUseCase.GetById(id);

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<FindProductsResponse>> GetAll(int page = 1, int pageSize = 10, string sortOrder = "asc")
        {
            try
            {
                var products = await _productUseCase.LoadAll(page, pageSize, sortOrder);

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateById(Guid id, UpdateProduct product)
        {
            try
            {
                await _productUseCase.UpdateById(id, product);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }
    }
}
