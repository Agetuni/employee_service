using EmployeeService.Application.Models;
using EmployeeService.Domain.Models;


namespace EmployeeService.Application.Queries;
public class GetPositoins : IRequest<OperationResult<List<Position>>>
{
    public RecordStatus? RecordStatus { get; set; }
}
public class GetPositoinsHandler : IRequestHandler<GetPositoins, OperationResult<List<Position>>>
{
    private readonly IRepositoryBase<Position> _position;
    public GetPositoinsHandler(IRepositoryBase<Position> _position) => this._position = _position;
    public async Task<OperationResult<List<Position>>> Handle(GetPositoins request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<List<Position>>();
        var positions = _position.Where(x =>
        x.RecordStatus != RecordStatus.Deleted &&
        (
            request.RecordStatus == null ||
            (int)request.RecordStatus == (int)x.RecordStatus)
        ).ToList();

        if (positions.Count() == 0)
        {
            result.AddError(ErrorCode.NotFound, "Record doesn't exist.");
            return result;
        }

        result.Payload = positions;
        result.Message = "Operation success";
        return result;

    }
}

