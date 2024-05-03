using System.Text.Json.Serialization;

namespace Porsche.Domain.Dtos;

public class UserDto
{
    public Guid Id { get; set; }
    
    public string FirstName { get; set; } = null!;
    
    public string SecondName { get; set; } = null!;
    
    public string? PhotoPath { get; set; }
}