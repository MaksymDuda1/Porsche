using Microsoft.AspNetCore.Http;

namespace Porsche.Domain.Dtos;

public class UpdatePorscheCenterDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public string Address { get; set; } = null!;
    
    public IFormFile? PhotoPath { get; set; }
    
}