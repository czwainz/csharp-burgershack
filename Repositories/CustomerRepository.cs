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










  }
}
