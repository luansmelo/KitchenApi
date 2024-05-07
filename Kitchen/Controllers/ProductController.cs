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
    }
}
