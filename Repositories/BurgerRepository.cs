using System;
using System.Collections.Generic;
using BurgerShack.Db;
using BurgerShack.Models;

namespace BurgerShack.Repositories
{
  public class BurgerRepository
  {

    public IEnumerable<Burger> GetAllBurgers()
    {
      return FakeDB.Burgers;
    }

    public Burger GetBurgerByID(int id)
    {
      try
      {
        return FakeDB.Burgers[id];
      }

      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }

    public Burger AddBurger(Burger newburger)
    {
      FakeDB.Burgers.Add(newburger);
      return newburger;
    }


    public Burger EditBurger(int id, Burger newBurger)
    {
      try
      {
        FakeDB.Burgers[id] = newBurger;
        return newBurger;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }

    public bool DeleteBurger(int id)
    {
      try
      {
        FakeDB.Burgers.Remove(FakeDB.Burgers[id]);
        return true;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return false;
      }
    }




    public BurgerRepository()
    {

    }
  }
}