using System.ComponentModel.DataAnnotations;

namespace EmployeeService.Application.Commands.Positions;
public class CreatePosition : IRequest<OperationResult<Position>>
{
    public string Name { get; set; }
}
public class CreatePositionHandler : IRequestHandler<CreatePosition, OperationResult<Position>>
{
    private readonly IRepositoryBase<Position> _position;
    public CreatePositionHandler(IRepositoryBase<Position> _position) => this._position = _position;
    public async Task<OperationResult<Position>> Handle(CreatePosition request, CancellationToken cancellationToken)
    {
        var result = new OperationResult<Position>();
        try
        {  
            if (_position.ExistWhere(x => x.Name == request.Name && x.RecordStatus != Domain.Common.RecordStatus.Deleted))
            {
                result.AddError(ErrorCode.RecordAlreadyExists, "Record already exists.");
                return result;
            }
            var position = Position.Create(request.Name);
            await _position.AddAsync(position);

            result.Payload = position;
            result.Message = "Operation success";
            return result;
        }
        catch (ValidationException ex) 
        { 

        }
        return result;
    }
}
