using FluentValidation;

namespace Kitchen.Models.Measure.Validation
{
    public class MeasurementInputValidation : AbstractValidator<MeasurementInput>
    {
      public MeasurementInputValidation() {
            RuleFor(c => c.Name).NotEmpty();
      }
    }
}
