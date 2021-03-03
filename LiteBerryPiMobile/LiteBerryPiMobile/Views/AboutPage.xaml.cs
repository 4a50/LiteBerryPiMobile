using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LiteBerryPiMobile.Views
{
  public partial class AboutPage : ContentPage
  {
    public AboutPage()
    {
      InitializeComponent();
    }
    void OnButtonClicked(object sender, EventArgs e)
    {
      (sender as Button).Text = "Click me again!";
    }
  }
}