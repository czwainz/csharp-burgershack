using System;
using System.Collections.Generic;
using Dapper;
using BurgerShack.Models;
using System.Data;

namespace BurgerShack.Repositories
{
  public class CustomerRepository
  {
    private readonly IDbConnection _db;

    public CustomerRepository(IDbConnection db)
    {
      _db = db;
    }


    public Customer AddCustomer(Customer newCust)
    {
      int id = _db.ExecuteScalar<int>(@"INSERT INTO Sides (name, favoriteBurgers)
      VALUES (@Name, @FavoriteBurgers); 
 	      SELECT LAST_INSERT_ID();",
         newCust);
      if (id == 0)
      {
        return null;
      }
      newCust.Id = id;
      return newCust;
    }


    public bool DeleteCustomer(int id)
    {
      int success = _db.Execute(@"DELETE FROM Customers WHERE id = @id", new { id });
      if (success != 1) return false;
      return true;
    }








  }
}
