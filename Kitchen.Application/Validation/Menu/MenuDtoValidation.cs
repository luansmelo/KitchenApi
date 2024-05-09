using FluentValidation;
using Kitchen.Application.DTOs;

namespace Kitchen.Application.Validation.Menu
{
    public class MenuDtoValidation : AbstractValidator<MenuDto>
    {
        public MenuDtoValidation()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
