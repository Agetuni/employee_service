namespace EmployeeService.Application.Commands;

public class UpdatePositionStatus : IRequest<OperationResult<Position>>
{
    public long Id { get; set; }
    public RecordStatus RecordStatus { get; set; }
}
public class UpdatePositionStatusHandler : IRequestHandler<UpdatePositionStatus, OperationResult<Position>>
{
    private readonly IRepositoryBase<Position> _position;
    public UpdatePositionStatusHandler(IRepositoryBase<Position> _position) => this._position = _position;
    public async Task<OperationResult<Position>> Handle(UpdatePositionStatus request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<Position>();
        //
        var position = _position.FirstOrDefault(x => x.Id == request.Id && x.RecordStatus != RecordStatus.Deleted);
        if (position == null)
        {
            result.AddError(ErrorCode.RecordAlreadyExists, "Record doesn't exist.");
            return result;
        }
        position.RecordStatus =request.RecordStatus;
        _position.Update(position);

        result.Payload = position;
        result.Message = "Operation success";
        return result;
    }
}
