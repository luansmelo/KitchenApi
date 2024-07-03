using FluentValidation;
using Kitchen.Application.DTOs;

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
