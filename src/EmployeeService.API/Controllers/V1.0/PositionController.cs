

namespace EmployeeService.API.Controllers.V1._0;
public class PositionController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] PositionDto request)
    {
        var result = await _mediator.Send(new CreatePosition { Name = request.Name, Description = request.Description });
        var client = _mapper.Map<PositionDetailDto>(result.Payload);
        return result.IsError ? HandleErrorResponse(result.Errors) : Ok(client);
    }
    [HttpPut("Update/{id}")]
    public async Task<IActionResult> Update([FromBody] PositionDto request, long id)
    {
        var result = await _mediator.Send(new UpdatePosition { Name = request.Name, Description = request.Description, Id = id });
        var client = _mapper.Map<PositionDetailDto>(result.Payload);
        return result.IsError ? HandleErrorResponse(result.Errors) : Ok(client);
    }
    [HttpPut("UpdateStatus/{id}")]
    public async Task<IActionResult> Update([FromBody] RecordStatusDto request, long id)
    {
        var result = await _mediator.Send(new UpdatePositionStatus {RecordStatus=request.Status , Id = id });
        var client = _mapper.Map<PositionDetailDto>(result.Payload);
        return result.IsError ? HandleErrorResponse(result.Errors) : Ok(client);
    }
    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await _mediator.Send(new DeletePosition { Id = id });
        var client = _mapper.Map<PositionDetailDto>(result.Payload);
        return result.IsError ? HandleErrorResponse(result.Errors) : Ok(client);
    }
    [HttpGet]
    public async Task<IActionResult> GetAll(RecordStatus? recordStatus)
    {
        var result = await _mediator.Send(new GetPositoins { RecordStatus = recordStatus });
        var client = _mapper.Map<List<PositionDetailDto>>(result.Payload);
        return result.IsError ? HandleErrorResponse(result.Errors) : Ok(client);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        var result = await _mediator.Send(new GetPosition { Id = id });
        var client = _mapper.Map<PositionDetailDto>(result.Payload);
        return result.IsError ? HandleErrorResponse(result.Errors) : Ok(client);
    }
    [HttpGet("Search")]
    public async Task<IActionResult> Search(string name)
    {
        var result = await _mediator.Send(new SearchPosition { Name=name });
        var client = _mapper.Map<PositionDetailDto>(result.Payload);
        return result.IsError ? HandleErrorResponse(result.Errors) : Ok(client);
    }
}
