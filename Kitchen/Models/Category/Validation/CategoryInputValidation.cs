using FluentValidation;

namespace Kitchen.Models.Category.Validation
{
    public class CategoryInputValidation : AbstractValidator<CategoryInput>
    {
        public CategoryInputValidation() 
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
