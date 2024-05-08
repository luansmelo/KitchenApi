using Kitchen.Domain.Contracts.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Kitchen.Controllers
{
    [Route("api/v1/product")]
    [ApiController]
    public class ProductController(IProductUseCase productUseCase) : ControllerBase
    {   
        private readonly IProductUseCase _productUseCase = productUseCase;

        [HttpPost]
        public async Task<IActionResult> Add(ProductInput input)
        {
            try
            {
                await _productUseCase.AddProduct(input);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpPost("add/ingredient")]
        public async Task<IActionResult> AddInput(AddIngredientToProductInput input)
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

        [HttpDelete("remove/ingredient")]
        public async Task<IActionResult> DeleteIngredient(RemoveInputToProduct product)
        {
            try
            {
                await _productUseCase.RemoveInputToProduct(product);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponse>> GetById(Guid id)
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
        public async Task<ActionResult<FindProductResponse>> GetAll(int page = 1, int pageSize = 10, string sortOrder = "asc")
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
