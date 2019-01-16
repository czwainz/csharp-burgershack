using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Side
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [MinLength(6)]
    public string Description { get; set; }
    [Range(5, 100)]
    public float Price { get; set; }


  }
}