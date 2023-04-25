namespace EmployeeService.Application.Commands;

public class DeletePosition : IRequest<OperationResult<Position>>
{
    public long Id { get; set; }
}
internal class DeletePositionHandler : IRequestHandler<DeletePosition, OperationResult<Position>>
{

    private readonly IRepositoryBase<Position> _position;
    public DeletePositionHandler(IRepositoryBase<Position> _position) => this._position = _position;
    public async Task<OperationResult<Position>> Handle(DeletePosition request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<Position>();

        var position = _position.FirstOrDefault(x => x.Id == request.Id);
        if (position == null)
        {
            result.AddError(ErrorCode.NotFound, "Record doesn't exist.");
            return result;
        }
        if (position.IsReadOnly == true)
        {
            result.AddError(ErrorCode.ServerError, "Record cannot be deleted.");
            return result;
        }
        position.Delete();
        _position.Update(position);

        result.Payload = position;
        result.Message = "Operation success";
        return result;
    }
}