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
      int id = _db.ExecuteScalar<int>(@"INSERT INTO Customers (name)"
      + "VALUES (@Name); SELECT LAST_INSERT_ID()", new
      {
        newCust.Name,
      });
      newCust.Id = id;
      return newCust;
    }

    //DeleteCustomer
    public bool DeleteCustomer(int id)
    {
      int success = _db.Execute(@"DELETE FROM Customers WHERE id = @id", new { id });
      if (success != 1) return false;
      return true;
    }








  }
}
