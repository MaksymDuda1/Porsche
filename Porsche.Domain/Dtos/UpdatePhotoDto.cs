using Microsoft.AspNetCore.Http;

namespace Porsche.Domain.Dtos;

public class UpdatePhotoDto
{
    public Guid CarId { get; set; }
    
    public string OldPhotoName { get; set; } = null!;
    
    public IFormFile NewPhoto { get; set; } = null!;
}