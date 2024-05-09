using System.ComponentModel.DataAnnotations;
using System.Reflection.PortableExecutable;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Porsche.Domain.Enums;

namespace Porsche.Domain.Dtos;

public class CreateCarDto
{
    public string IdentityCode { get; set; } = null!;
    
    public string Model { get; set; } = null!;
    
    public int YearOfEdition { get; set; }
    
    public BodyType BodyType { get; set; }
    
    public Color Color { get; set; }
    
    public string Engine { get; set; } = null!;
    
    public float FuelConsumption { get; set; }
    
    public float Price { get; set; }

    public Status Status { get; set; }
    public Guid? PorscheCenterId  { get; set; }

    public PorscheCenterDto? PorscheCenter { get; set; }
    public List<IFormFile>? Photos { get; set; } = new List<IFormFile>();
}