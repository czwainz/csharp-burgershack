using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Customer
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }


  }
}