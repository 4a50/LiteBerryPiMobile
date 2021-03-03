using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LiteBerryPiMobile.ViewModels
{
  public class DesignViewModel : BaseViewModel
  {
    public DesignViewModel()
    {
      Title = "LiteBerry Designer";
      OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.google.com/"));
    }
    public ICommand OpenWebCommand { get; }
  }
}