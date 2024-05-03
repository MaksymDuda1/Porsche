namespace Porsche.Domain.Entities;

public class PhotoEntity
{
    public Guid Id { get; set; }
    
    public string Path { get; set; } = null!;
    
    public string FileName { get; set; } = null!;
    
    public Guid? CarId { get; set; }
    
    public CarEntity? Car { get; set; }
}