using System;
using System.Collections.Generic;
using Dapper;
using BurgerShack.Models;
using System.Data;

namespace BurgerShack.Repositories
{
  public class SideRepository
  {
    private readonly IDbConnection _db;

    public SideRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Side> GetAllSides()
    {
      return _db.Query<Side>("SELECT * FROM Sides");
    }

    public Side GetSidesByID(int id)
    {
      return _db.QueryFirstOrDefault<Side>($"SELECT * FROM Sides WHERE id = @id", new { id });
    }

    public Side AddSide(Side newSide)
    {
      int id = _db.ExecuteScalar<int>(@"INSERT INTO Sides (name, description, price)
      VALUES (@Name, @Description, @Price); 
 	      SELECT LAST_INSERT_ID();",
         newSide);
      if (id == 0)
      {
        return null;
      }
      newSide.Id = id;
      return newSide;
    }

    public Side EditSide(int id, Side newSide)
    {
      try
      {
        return _db.QueryFirstOrDefault<Side>($@"
        UPDATE Sides SET
        Name = @Name,
        Description = @Description,
        Price = @Price
        WHERE Id = @Id;
        SELECT * FROM Sides WHERE id = @Id;
        ", newSide);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }

    public bool DeleteSide(int id)
    {
      // try
      // {
      int success = _db.Execute(@"DELETE FROM Sides WHERE id = @id", new { id });
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