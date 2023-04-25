using System.ComponentModel.DataAnnotations;

namespace EmployeeService.API.Contracts.Positions;
public class PositionDto
{
    [Required(ErrorMessage = "Position name is mandatory.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Position description is mandatory.")]
    public string Description { get; set; }
}
