namespace EmployeeService.Application.Commands;

public class UpdatePosition : IRequest<OperationResult<Position>>
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
public class EditPositionHandler : IRequestHandler<UpdatePosition, OperationResult<Position>>
{
    private readonly IRepositoryBase<Position> _position;
    public EditPositionHandler(IRepositoryBase<Position> _position) => this._position = _position;
    public async Task<OperationResult<Position>> Handle(UpdatePosition request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<Position>();
        //
        var position = _position.FirstOrDefault(x => x.Id == request.Id && x.RecordStatus != RecordStatus.Deleted);
        if(position == null)
        {
            result.AddError(ErrorCode.RecordAlreadyExists, "Record doesn't exist.");
            return result;
        }
        position.Update(request.Name, request.Description);
        _position.Update(position);

        result.Payload = position;
        result.Message = "Operation success";
        return result;
    }
}
