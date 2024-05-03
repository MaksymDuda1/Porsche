using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Porsche.Domain.Enums;

namespace Porsche.Domain.Entities;

public class CarEntity
{
    public Guid Id { get; set; }
    
    [MaxLength(100)]
    public string IdentityCode { get; set; } = null!;
    
    [MaxLength(100)]
    public string Model { get; set; } = null!;
    
    public int YearOfEdition { get; set; }
    
    public BodyType BodyType { get; set; }
    
    public Color Color { get; set; }
    
    [MaxLength(100)]
    public string Engine { get; set; } = null!;
    
    public float FuelConsumption { get; set; }
    
    public float Price { get; set; }
    
    public bool IsAvailable { get; set; } = true;
    
    [JsonIgnore] 
    public Guid? PorscheCenterId  { get; set; }
    
    [JsonIgnore] 
    public PorscheCenterEntity? PorscheCenter { get; set; }
    
    [JsonIgnore] 
    public List<PhotoEntity>? Photos { get; set; } = new List<PhotoEntity>();
    
    [JsonIgnore] 
    public List<UserEntity>? Users { get; set; } = new List<UserEntity>();
    
    public List<UserCarEntity> UsersCars { get; set; } = new List<UserCarEntity>();
}