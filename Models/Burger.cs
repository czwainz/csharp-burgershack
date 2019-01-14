using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Burger
  {
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Range(5, 100)]
    public float Price { get; set; }

    public Burger(string name, string desc, float price)
    {
      Name = name;
      Description = desc;
      Price = price;
    }
  }
}