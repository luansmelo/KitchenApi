using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Contracts.UseCases.Product;
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

        [HttpPost("add/input")]
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
    }
}
