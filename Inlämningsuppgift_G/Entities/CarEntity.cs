using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inlämningsuppgift_G.Entities;

internal class CarEntity
{
    [Key]
    public int Id { get; set; }
    public string CarName { get; set; } = null!;

    [Column (TypeName = "money")]
    public decimal CarPrice { get; set; }


    public int CarModelId { get; set; }
    public CarModelEntity CarModel { get; set; } = null!;


    public int CarTypeId { get; set; }
    public CarTypeEntity CarType { get; set; } = null!;
}
