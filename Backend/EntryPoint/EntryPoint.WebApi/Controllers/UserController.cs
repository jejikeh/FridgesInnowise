using Identity.Application.Requests.Commands.ConfirmEmail;
using Identity.Application.Requests.Commands.Login;
using Identity.Application.Requests.Commands.Register;
using Identity.Application.Requests.Commands.ResendConfirmEmail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EntryPoint.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(ISender sender) : ControllerBase
{
    [HttpPost("register")]
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

    [HttpGet("resend-confirm-email")]
    public async Task<IActionResult> ResendConfirmEmail([FromQuery] ResendConfirmEmailRequest request)
    {
        var result = await sender.Send(request);
        
        // TODO(jejikeh)?: move that to ErrorHandlePipeline in Identity.Application
        if (result.IsFailure)
        {
            return BadRequest(result.GetFailure());
        }
        
        return Ok(result.GetSuccess()?.Value);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser([FromBody] LoginRequest request)
    {
        var result = await sender.Send(request);

        if (result.IsFailure)
        {
            return BadRequest(result.GetFailure());
        }
        
        return Ok(result.GetSuccess());
    }
}