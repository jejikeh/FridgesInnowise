using Identity.Application.Common.Models.Requests.Register;
using Identity.Application.Services;
using MediatR;
using Results.Models;

namespace Identity.Application.Requests.Commands.Register;

public class RegisterHandler : IRequestHandler<RegisterRequest, Result<RegisterSuccess, RegisterError>>
{
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;
    
    public RegisterHandler(IUserRepository userRepository, IEmailService emailService)
    {
        _userRepository = userRepository;
        _emailService = emailService;
    }

    public async Task<Result<RegisterSuccess, RegisterError>> Handle(RegisterRequest request, CancellationToken cancellationToken)
    {
        var responseFromRegister = await _userRepository.RegisterAsync(request.Email, request.UserName, request.Password);
        if (responseFromRegister.IsFailure)
        {
            return responseFromRegister.GetFailure() ?? Error.InternalError<RegisterError>();
        }

        await _emailService.SendEmailAsync();
    }
}