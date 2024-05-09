using FluentValidation;
using Kitchen.Application.DTOs.Group;
using Kitchen.Application.DTOs.Measurement;

namespace Kitchen.Application.Validation.Measurement
{
    public class MeasurementDtoValidation : AbstractValidator<MeasurementDto>
    {
        public MeasurementDtoValidation()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
