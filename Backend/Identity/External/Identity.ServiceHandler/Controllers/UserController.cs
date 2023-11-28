using Identity.Application.Common.Models.Requests.UpdateAuthorizeToken;
using Identity.Application.Requests.Commands.ConfirmEmail;
using Identity.Application.Requests.Commands.Login;
using Identity.Application.Requests.Commands.Register;
using Identity.Application.Requests.Commands.ResendConfirmEmail;
using Identity.Application.Requests.Commands.UpdateAuthorizeToken;
using Identity.Application.Requests.Queries.GetRefreshTokens;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.PresentationInjectionHelpers.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(ISender sender) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterRequest request)
    {
        var result = await sender.Send(request);
        
        // TODO(jejikeh)?: move that to ErrorHandlePipeline in Identity.Fridges.Application
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
        
        // TODO(jejikeh)?: move that to ErrorHandlePipeline in Identity.Fridges.Application
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
        
        // TODO(jejikeh)?: move that to ErrorHandlePipeline in Identity.Fridges.Application
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
        
        return Ok(result.GetSuccess()?.Value);
    }
    
    // TODO(jejikeh): Move that to separate controller
    [HttpPost("update-access-token")]
    public async Task<IActionResult> UpdateAccessToken([FromBody] UpdateAuthorizeTokenRequest request)
    {
        var result = await sender.Send(request);

        if (result.IsFailure)
        {
            return BadRequest(result.GetFailure());
        }
        
        return Ok(result.GetSuccess()?.Value);
    }

    [Authorize]
    [HttpGet("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromQuery] GetRefreshTokensRequest request)
    {
        var result = await sender.Send(request);

        if (result.IsFailure)
        {
            return BadRequest(result.GetFailure());
        }
        
        return Ok(result.GetSuccess()?.Value);
    }
}