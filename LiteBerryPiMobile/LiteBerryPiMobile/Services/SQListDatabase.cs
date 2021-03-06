using LiteBerryPiMobile.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace LiteBerryPiMobile.Services
{
  class SQListDatabase : IDataStore<LBData>
  {
    readonly SQLiteAsyncConnection database;

    public SQListDatabase()
    {
      string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LPB.db3");
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
      try
      {
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
    public async Task<LBData> GetNodeByDesignName (string name)
    {
      return await database.Table<LBData>().Where(i => i.DesignName == name).FirstOrDefaultAsync();
    }

    public async Task<List<LBData>> GetItemsAsync(bool forceRefresh = false)
    {
      return await database.Table<LBData>().ToListAsync();
    }
    public async Task<LBData> GetNodeByCoord(string nodecoord)
    {
      return await database.Table<LBData>().Where(i => i.NodeCoord == nodecoord).FirstOrDefaultAsync();
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
