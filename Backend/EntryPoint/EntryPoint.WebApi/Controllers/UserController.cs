using Identity.Application.Requests.Commands.ConfirmEmail;
using Identity.Application.Requests.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EntryPoint.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterRequest request)
    {
        var result = await sender.Send(request);
        
        // TODO(jejikeh)?: move that to ErrorHandlePipeline in Identity.Application
        if (result.IsFailure)
        {
            return BadRequest(result.GetFailure());
        }
        
        return Ok(result.GetSuccess()?.Value);
    }

    [HttpGet("confirm-email")]
    public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailRequest request)
    {
        var result = await sender.Send(request);
        
        // TODO(jejikeh)?: move that to ErrorHandlePipeline in Identity.Application
        if (result.IsFailure)
        {
            return BadRequest(result.GetFailure());
        }
        
        return Ok(result.GetSuccess()?.Value);
    }
}