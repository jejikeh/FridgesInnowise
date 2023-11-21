using Identity.Application.Common.Models.Requests.Register;
using MediatR;
using Results.Models;

namespace Identity.Application.Requests.Commands.Register;

public class RegisterRequest : IRequest<Result<RegisterSuccess, RegisterError>>
{
    public required string Email { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
}