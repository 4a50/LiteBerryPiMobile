using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiteBerryPiMobile.Services
{
  public interface IDataStore<T>
  {
    Task<bool> AddItemAsync(T item);
    Task<bool> UpdateItemAsync(T item);
    Task<bool> DeleteItemAsync(int id);
    Task<bool> DeleteAllEntries();
    Task<T> GetItemAsync(int id);
    Task<T> GetNodeByCoord(string styleid);
    Task<T> GetNodeByDesignName(string name);
    Task<List<T>> GetItemsAsync(bool forceRefresh = false);
  }
}
