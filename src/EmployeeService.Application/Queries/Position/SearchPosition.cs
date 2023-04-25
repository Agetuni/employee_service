namespace EmployeeService.Application.Queries;
public class SearchPosition : IRequest<OperationResult<Position>>
{
    public string Name { get; set; }
}
public class SearchPositionHandler : IRequestHandler<SearchPosition, OperationResult<Position>>
{
    private readonly IRepositoryBase<Position> _position;
    public SearchPositionHandler(IRepositoryBase<Position> _position) => this._position = _position;
    public async Task<OperationResult<Position>> Handle(SearchPosition request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<Position>();
        
        //
        var position = _position.FirstOrDefault(x => x.Name == request.Name && x.RecordStatus != RecordStatus.Deleted);
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
