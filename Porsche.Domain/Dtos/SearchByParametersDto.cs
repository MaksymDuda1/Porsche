using Porsche.Domain.Enums;

namespace Porsche.Domain.Dtos;

public class SearchByParametersDto
{
    public string? Model { get; set; }
    
    public BodyType[]? BodyType { get; set; }
    
    public Color[]? Color { get; set; }
    
    public int? MinYearOfRelease { get; set; }
    
    public int? MaxYearOfRelease { get; set; }
    
    public float? MinPrice { get; set; }
    
    public float? MaxPrice { get; set; }
    
    public string[]? Engine { get; set; }
    
    public string[]? PorscheCenter { get; set; }
}