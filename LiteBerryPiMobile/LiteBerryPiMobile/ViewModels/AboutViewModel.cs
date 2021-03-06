using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LiteBerryPiMobile.ViewModels
{
  public class AboutViewModel : BaseViewModel
  {
    public AboutViewModel()
    {
      Title = "LiteBerry Home";
      OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
    }

    public ICommand OpenWebCommand { get; }
    void OnButtonClicked(object sender, EventArgs e)
    {
      (sender as Button).Text = "Some Thoughts are sent through the ether";
    }


  }
}