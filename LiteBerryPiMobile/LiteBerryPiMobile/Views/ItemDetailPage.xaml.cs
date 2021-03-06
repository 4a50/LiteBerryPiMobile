using LiteBerryPiMobile.ViewModels;
using Xamarin.Forms;

namespace LiteBerryPiMobile.Views
{
  public partial class ItemDetailPage : ContentPage
  {
    public ItemDetailPage()
    {
      InitializeComponent();
      BindingContext = new ItemDetailViewModel();
    }
  }
}