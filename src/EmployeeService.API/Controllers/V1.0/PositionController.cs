using EmployeeService.API.Resources;
using Microsoft.Extensions.Localization;

namespace EmployeeService.API.Controllers.V1._0;
public class PositionController : BaseController
{
    [HttpPost("Create")]
    public async Task<IActionResult> CreateClient([FromBody] CreatePositionDto request)
    {
        
        var result = await _mediator.Send(new CreatePosition { Name = request.Name });
        var client = _mapper.Map<PositionDetailDto>(result.Payload);
        return result.IsError ? HandleErrorResponse(result.Errors) : Ok(client);
     
    }
}
