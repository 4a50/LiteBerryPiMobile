using LiteBerryPiMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LiteBerryPiMobile.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class ViewSavedPage : ContentPage
  {
    readonly ViewSavedModel _vm;
    private string text = string.Empty;
    public string Text {
      get { return text;}
      set
      {
        if (text == value)
        {
          return;
        }
        text = value;
      }
    }
    public ViewSavedPage()
    {
      InitializeComponent();
      BindingContext = _vm = new ViewSavedModel();
      Title = "Saved Designs";
    }
    public void OnNukedClicked(Object sender, EventArgs e)
    {
      Task.Run(async () => await _vm.NukeTheDatabase());      
    }
    protected override void OnAppearing()
    {
      Task.Run(async () => await _vm.PopulateObservableList());
    }
  }
}