using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
    
    //public ObservableCollection LiteNodes { get; set }    
   



    public DesignViewModel()
    {
      Title = "LiteBerry Designer";
      OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.google.com/"));

    }
    
    
  }
  
}