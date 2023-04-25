using EmployeeService.Domain.Common;

namespace EmployeeService.API.Contracts.Positions;

public class PositionDetailDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public RecordStatus RecordStatus { get; set; }
}
