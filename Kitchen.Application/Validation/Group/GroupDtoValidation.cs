using FluentValidation;
using Kitchen.Application.DTOs;

namespace Kitchen.Application.Validation
{
    public class GroupDtoValidation : AbstractValidator<GroupDto>
    {
        public GroupDtoValidation()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
