using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Porsche.Domain.Enums;

namespace Porsche.Domain.Dtos;

public class UpdateCarDto
{
    public Guid Id { get; set; }
    
    public string Model { get; set; } = null!;
    
    public int YearOfEdition { get; set; }
    
    public BodyType BodyType { get; set; }
    
    public Color Color { get; set; }
    
    [MaxLength(100)]
    public string Engine { get; set; } = null!;
    
    public float FuelConsumption { get; set; }
    
    public float Price { get; set; }
    
    public Status Status { get; set; }
    
    public Guid? PorscheCenterId  { get; set; }
    
    public List<PhotoDto>? Photos { get; set; } = new List<PhotoDto>();
    
}