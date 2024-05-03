using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace Porsche.Domain.Entities;

public class UserEntity : IdentityUser<Guid>
{
    
    public string FirstName { get; set; } = null!;
    
    public string SecondName { get; set; } = null!;
    
    public string? PhotoPath { get; set; }
    
    public List<CarEntity>? SavedCars { get; set; } = new List<CarEntity>();
    
    public List<UserCarEntity> UsersCars { get; set; } = new List<UserCarEntity>();

}