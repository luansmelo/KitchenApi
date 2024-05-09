using FluentValidation;
using Kitchen.Application.DTOs.Ingredient;

namespace Kitchen.Application.Validation.Ingredient
{
    internal class IngredientDtoValidation : AbstractValidator<IngredientDto>
    {
        public IngredientDtoValidation()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Code).NotEmpty();
            RuleFor(c => c.UnitPrice).NotEmpty().GreaterThanOrEqualTo(0); ;
            RuleFor(c => c.MeasurementId).NotEmpty();
            RuleFor(c => c.GroupIds).NotEmpty();
        }
    }
}
