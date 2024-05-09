using FluentValidation;
using Kitchen.Application.DTOs.Group;

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
