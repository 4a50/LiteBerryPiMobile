using LiteBerryPiMobile.Models;
using LiteBerryPiMobile.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LiteBerryPiMobile.ViewModels
{
  public class DesignViewModel : BaseViewModel
  {

    public string Rows { get; set; }
    public string Column { get; set; }
    public ICommand OpenWebCommand { get; }

    //public IDataStore<LBData> DataStore => DependencyService.Get<IDataStore<LBData>>();
    //public ObservableCollection LiteNodes { get; set }    




    public DesignViewModel()
    {
      Title = "LiteBerry Designer";
      OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.google.com/"));

    }

    public async Task<LBData> GetWithDesignName(string name)
    {
      return await DataStore.GetNodeByDesignName(name);
    }

    public async void Save(List<string> selectedNodes, string name)
    {
      //TODO: Add already exists condition
      foreach (string s in selectedNodes)
      {
        await DataStore.AddItemAsync(new LBData
        { 
          Id = 0,
          IsEnabled = true,
          NodeCoord = s,
          DesignName = name
        });
      }
    }
  }
}