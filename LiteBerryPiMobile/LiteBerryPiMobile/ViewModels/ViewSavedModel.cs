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
    //public IDataStore<LBData> DataStore => DependencyService.Get <IDataStore<LBData>>();
    //public ObservableCollection<LBData> DesignItems { get; set; }
    public ObservableCollection<DesignViewList> DesignItems { get; set; }
    private string text = string.Empty;
    public string Text
    {
      get { return text; }
      set
      {
        if (text == value)
        {
          return;
        }
        text = value;
      }
    }
    
    public ViewSavedModel()
    {
      Title = "List Saved Designs";
      DesignItems = new ObservableCollection<DesignViewList>();

     // Task.Run(async () => await PopulateObservableList());

    }

    public async Task PopulateObservableList()
    {
      List<DesignViewList> lst = new List<DesignViewList>();
      try
      {
        var LBDataItems = await DataStore.GetItemsAsync();
        DesignItems.Clear();
        foreach (var lbdata in LBDataItems)
        {
          DesignViewList dvl = new DesignViewList {DesignName = lbdata.DesignName};
          if (!lst.Exists(x => x.DesignName == lbdata.DesignName))
          {
            lst.Add(dvl);
            DesignItems.Add(dvl);
          }
          
          Debug.WriteLine($"PopList DesignName: {lbdata.DesignName} ID: {lbdata.Id}");
        }

      }

      catch(Exception e)
      {
        Debug.WriteLine(e.Message);
      }
    }
    public async Task NukeTheDatabase()
      {
      Debug.WriteLine($"Nuked? {await DataStore.DeleteAllEntries()}");
      }
  }
}
