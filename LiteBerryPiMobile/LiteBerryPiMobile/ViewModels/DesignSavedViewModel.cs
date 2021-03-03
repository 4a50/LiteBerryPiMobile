using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LiteBerryPiMobile.ViewModels
{
  public class DesignSavedViewModel : BaseViewModel
  {
    public DesignSavedViewModel()
    {
      Title = "You Designed is Saved!";      
    }

    public ICommand OpenWebCommand { get; }
      void OnButtonClicked(object sender, EventArgs e)
      {
        (sender as Button).Text = "Some Thoughts are sent through the ether";
      }


  }
}