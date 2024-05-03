namespace Porsche.Domain.Entities;

public class UserCarEntity
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    
    public UserEntity? User { get; set; }
    
    public Guid CarId { get; set; }
    
    public CarEntity? Car { get; set; }
    
}