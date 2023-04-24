namespace EmployeeService.Domain.Models;
public class Position : BaseEntity
{
    public string Name { get; set; }

    public static Position Create(string name)
    {
        var position = new Position { Name = name };

        //validation
        var validator = new PositionValidator();
        var response = validator.Validate(position);
        if (response.IsValid) return position;// valid
        var exception = new NotValidException("Position is not valid");
        response.Errors.ForEach(vr => exception.ValidationErrors.Add(vr.ErrorMessage));
        throw exception;
    }
    public void Update(string name)
    {
        this.Name = name;

        //validation
        var validator = new PositionValidator();
        var response = validator.Validate(this);
        if (response.IsValid) return;//valid
        var exception = new NotValidException("Position is not valid");
        response.Errors.ForEach(vr => exception.ValidationErrors.Add(vr.ErrorMessage));
        throw exception;
    }
}
