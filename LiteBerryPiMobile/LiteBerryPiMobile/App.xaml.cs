using LiteBerryPiMobile.Services;
using LiteBerryPiMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LiteBerryPiMobile
{
  public partial class App : Application
  {

    public App()
    {
      InitializeComponent();

      DependencyService.Register<SQListDatabase>();
      MainPage = new AppShell();
    }

    protected override void OnStart()
    {
    }

    protected override void OnSleep()
    {
    }

    protected override void OnResume()
    {
    }
  }
}
