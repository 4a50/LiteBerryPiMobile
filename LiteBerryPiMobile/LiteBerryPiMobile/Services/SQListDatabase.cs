using System;
using System.Collections.Generic;
using System.Text;
using LiteBerryPiMobile.Models;
using System.Threading.Tasks;
using System.IO;
using SQLite;

namespace LiteBerryPiMobile.Services
{
  class SQListDatabase : IDataStore<LBData>
  {
    readonly SQLiteAsyncConnection database;
    SQListDatabase()
    {
      string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Items.db3");
      database = new SQLiteAsyncConnection(path);      
      database.CreateTableAsync<LBData>().Wait();
    }
    public async Task<bool> AddItemAsync(LBData item)
    {
      try
      {
        int addedItem = await database.InsertAsync(item);
        return true;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return false;
      }
    }

    public async Task<bool> DeleteItemAsync(int id)
    {
      try { 
      await database.DeleteAsync(id);
        return true;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return false;
      }
    }

    public async Task<LBData> GetItemAsync(int id)
    {
      return await database.Table<LBData>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<LBData>> GetItemsAsync(bool forceRefresh = false)
    {
      return await database.Table<LBData>().ToListAsync();
    }

    public async Task<bool> UpdateItemAsync(LBData item)
    {
      try 
      {
        int updatedItem = await database.UpdateAsync(item);
        return true;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return false;
      }
    }
  }
}
