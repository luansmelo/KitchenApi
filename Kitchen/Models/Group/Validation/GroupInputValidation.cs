using FluentValidation;

namespace Kitchen.Models.Group.Validation
{
    public class GroupInputValidation : AbstractValidator<GroupInput>
    {
        public GroupInputValidation()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
