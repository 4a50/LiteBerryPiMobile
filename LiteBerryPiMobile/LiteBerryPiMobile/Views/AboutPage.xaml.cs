using System;
using Xamarin.Forms;

namespace LiteBerryPiMobile.Views
{
  public partial class AboutPage : ContentPage
  {
    public bool truth { get; set; }

    public AboutPage()
    {
      InitializeComponent();
    }
    void OnButtonClicked(object sender, EventArgs e)
    {
      if (truth)
      {
        truth = false;
        (sender as Button).Text = "Send More Happy Thoughts!";
        (sender as Button).BackgroundColor = Color.Default;
        (sender as Button).CornerRadius = 0;
        //(sender as Button).BackgroundColor = ResourceDictionary;

      }
      else
      {
        truth = true;
        (sender as Button).Text = "Some Happy Thoughts Are On There Way!";
        (sender as Button).BackgroundColor = Color.FromHex("#ff2400");
        (sender as Button).CornerRadius = 40;
      }
      Console.WriteLine($"Persist: {truth}");
    }
  }
}