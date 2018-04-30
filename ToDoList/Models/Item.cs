using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;

namespace ToDoList.Models
{
  public class Item
  {
    private int _id;
    private string _description;

    public Item(string Description, int Id = 0)
   {
     _id = Id;
     _description = Description;
   }

    public string GetDescription()
    {
      return _description;
    }

    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }

    public string GetDate()
    {
      return _date;
    }

    public void SetDate(string newDate)
    {
      _date = newDate;
    }

    public string GetMemo()
    {
      return _memo;
    }

    public void SetMemo(string newMemo)
    {
      _memo = newMemo;
    }

    public string GetImportance()
    {
      return _importance;
    }

    public void SetImportance(string newImportance)
    {
      _importance = newImportance;
    }

    public int GetId()
    {
      return _id + 1;
    }

    public static List<Item> GetAll()
    {
        List<Item> allItems = new List<Item> {};
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM items;";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          int itemId = rdr.GetInt32(0);
          string itemDescription = rdr.GetString(1);
          Item newItem = new Item(itemDescription, itemId);
          allItems.Add(newItem);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
        return allItems;
    }

    public static Item Find(int searchId)
    {
      return _instances[searchId-1];
    }

    public void Save()
    {
      _instances.Add(this);
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

  }
}
