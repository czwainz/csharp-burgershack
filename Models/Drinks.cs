using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Drink
  {
    [Required]
    public string Name { get; set; }
    [Required]
    [MinLength(6)]
    public string Description { get; set; }
    [Range(5, 100)]
    public float Price { get; set; }

    public Drink(string name, string desc, float price)
    {
      Name = name;
      Description = desc;
      Price = price;
    }
  }
}