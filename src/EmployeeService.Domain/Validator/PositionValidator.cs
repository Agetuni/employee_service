namespace EmployeeService.Domain.Validator;
public class PositionValidator : AbstractValidator<Position>
{
    public PositionValidator()
    {

        RuleFor(x => x.Name)
              .NotNull().WithMessage("Position name can't be null")
              .NotEmpty().WithMessage("Position name can't be empty");
    }

}

