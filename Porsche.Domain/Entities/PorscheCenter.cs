namespace Porsche.Domain.Entities;

public class PorscheCenterEntity
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string Address { get; set; } = null!;
    
    public string? PhotoPath { get; set; }
    public List<CarEntity>? Cars { get; set; } = new List<CarEntity>();
}