using System.ComponentModel.DataAnnotations;

namespace Inlämningsuppgift_G.Entities;

public class CarModelEntity
{
    [Key]
    public int Id { get; set; }
    public string Model { get; set; } = null!;

}