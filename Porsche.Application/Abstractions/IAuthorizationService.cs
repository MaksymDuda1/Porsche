using Porsche.Domain.Dtos;

namespace Porsche.Application.Abstractions;

public interface IAuthorizationService
{
    Task<string> LoginUser(LoginDto loginDto);
    Task<string> RegisterUser(RegistrationDto registrationDto);
}