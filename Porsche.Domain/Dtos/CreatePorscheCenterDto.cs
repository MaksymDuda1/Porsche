using Microsoft.AspNetCore.Http;

namespace Porsche.Domain.Dtos;

public class CreatePorscheCenterDto
{
    public string Name { get; set; } = null!;
    
    public string Address { get; set; } = null!;
    
    public IFormFile? Photo { get; set; }
}