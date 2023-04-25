using EmployeeService.Domain.Models;

namespace EmployeeService.Application.Queries;
public class GetPosition : IRequest<OperationResult<Position>>
{
    public long Id { get; set; }
}
public class GetPositionHandler : IRequestHandler<GetPosition, OperationResult<Position>>
{
    private readonly IRepositoryBase<Position> _position;
    public GetPositionHandler(IRepositoryBase<Position> _position) => this._position = _position;
    public async Task<OperationResult<Position>> Handle(GetPosition request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<Position>();
        //
        var position = _position.FirstOrDefault(x => x.Id == request.Id && x.RecordStatus != RecordStatus.Deleted);
        if (position == null)
        {
            result.AddError(ErrorCode.NotFound, "Record doesn't exist.");
            return result;
        }
        result.Payload = position;
        result.Message = "Operation success";
        return result;
    }
}
