namespace Porsche.Domain.Dtos;

public class PorscheCenterDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string Address { get; set; } = null!;
    public string? PhotoPath { get; set; }
    
    public List<CarDto>? Cars { get; set; } = new List<CarDto>();
}