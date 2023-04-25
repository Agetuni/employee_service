namespace EmployeeService.Application.Commands;
public class CreatePosition : IRequest<OperationResult<Position>>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
public class CreatePositionHandler : IRequestHandler<CreatePosition, OperationResult<Position>>
{
    private readonly IRepositoryBase<Position> _position;
    public CreatePositionHandler(IRepositoryBase<Position> _position) => this._position = _position;
    public async Task<OperationResult<Position>> Handle(CreatePosition request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<Position>();

        if (_position.ExistWhere(x => x.Name == request.Name && x.RecordStatus != RecordStatus.Deleted))
        {
            result.AddError(ErrorCode.RecordAlreadyExists, "Record already exists.");
            return result;
        }
        var position = Position.Create(request.Name,request.Description);
        await _position.AddAsync(position);

        result.Payload = position;
        result.Message = "Operation success";
        return result;
    }
}
