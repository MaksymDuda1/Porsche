namespace Porsche.Domain.Dtos;

public class RegistrationDto
{
    public string FirstName { get; set; } = null!;
    
    public string SecondName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}