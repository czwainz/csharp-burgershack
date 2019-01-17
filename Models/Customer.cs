using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
  public class Customer
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    public IEnumerable<Burger> FavoriteBurgers { get; set; }

    // public IEnumerable<Side> FavoriteSides { get; set; }

  }
}