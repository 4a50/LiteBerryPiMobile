using LiteBerryPiMobile.Services;
using Xamarin.Forms;

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
