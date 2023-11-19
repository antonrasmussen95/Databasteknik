using System.ComponentModel.DataAnnotations;

namespace Inlämningsuppgift_G.Entities;

public class CarTypeEntity
{
    [Key]   
    public int Id { get; set; }
    public string Type { get; set; } = null!;
}