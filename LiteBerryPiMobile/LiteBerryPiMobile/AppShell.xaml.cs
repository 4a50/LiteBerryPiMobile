using LiteBerryPiMobile.Views;
using Xamarin.Forms;

namespace LiteBerryPiMobile
{
  public partial class AppShell : Xamarin.Forms.Shell
  {
    public AppShell()
    {
      InitializeComponent();
      Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
      Routing.RegisterRoute(nameof(DesignPage), typeof(DesignPage));
      
      Routing.RegisterRoute(nameof(ViewSavedPage), typeof(ViewSavedPage));

    }

  }
}
