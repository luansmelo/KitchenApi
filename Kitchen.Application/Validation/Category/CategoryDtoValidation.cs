using FluentValidation;
using Kitchen.Application.DTOs.Category;

namespace Kitchen.Application.Validation
{
    public class CategoryDtoValidation : AbstractValidator<CategoryDto>
    {
        public CategoryDtoValidation() 
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
