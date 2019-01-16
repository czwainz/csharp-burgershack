using System;
using System.Collections.Generic;
using Dapper;
using BurgerShack.Models;
using System.Data;

namespace BurgerShack.Repositories
{
  public class BurgerRepository
  {
    private readonly IDbConnection _db;

    public BurgerRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Burger> GetAllBurgers()
    {
      return _db.Query<Burger>("SELECT * FROM Burgers");
    }

    public Burger GetBurgerByID(int id)
    {
      return _db.QueryFirstOrDefault<Burger>($"SELECT * FROM Burgers WHERE id = @id", new { id });
    }

    public Burger AddBurger(Burger newburger)
    {
      int id = _db.ExecuteScalar<int>(@"INSERT INTO Burgers (name, description, price)
      VALUES (@Name, @Description, @Price); 
 	      SELECT LAST_INSERT_ID();",
         newburger);
      if (id == 0)
      {
        return null;
      }
      newburger.Id = id;
      return newburger;
    }


    public Burger EditBurger(int id, Burger newBurger)
    {
      try
      {
        return _db.QueryFirstOrDefault<Burger>($@"
        UPDATE Burgers SET
        Name = @Name,
        Description = @Description,
        Price = @Price
        WHERE Id = @Id;
        SELECT * FROM Burgers WHERE id = @Id;
        ", newBurger);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }

    public bool DeleteBurger(int id)
    {
      // try
      // {
      int success = _db.Execute(@"DELETE FROM Burgers WHERE id = @id", new { id });
      if (success != 1) return false;
      return true;
      // }
      // catch (Exception ex)
      // {
      //   Console.WriteLine(ex);
      //   return false;
      // }
    }




    // public BurgerRepository()
    // {

    // }
  }
}