using FluentValidation;
using Kitchen.Application.DTOs.Product;

namespace Kitchen.Application.Validation.Product
{
    public class ProductDtoValidation : AbstractValidator<ProductDto>
    {
        public ProductDtoValidation()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Accession).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(c => c.Resource).NotEmpty();
            RuleFor(c => c.PreparationTime).NotEmpty();
            RuleFor(c => c.Photo_url).NotEmpty();
        }
    }
}
