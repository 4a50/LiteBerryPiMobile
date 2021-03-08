using LiteBerryPiMobile.Models;
using LiteBerryPiMobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LiteBerryPiMobile.ViewModels
{
  public class ViewSavedModel  : BaseViewModel
  {
    public IDataStore<LBData> DataStore => DependencyService.Get <IDataStore<LBData>>();
    public ObservableCollection<LBData> DesignItems { get; set; }
    public ViewSavedModel()
    {
      Title = "List Saved Designs";
      DesignItems = new ObservableCollection<LBData>();

    }

    public async Task PopulateObservableList()
    {
      try
      {
        var LBDataItems = await DataStore.GetItemsAsync();
        foreach (var lbdata in LBDataItems)
        {
          DesignItems.Add(lbdata);
        }
      }
      catch(Exception e)
      {
        Debug.WriteLine(e.Message);
      }

    }
  }
}
