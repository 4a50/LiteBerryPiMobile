using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LiteBerryPiMobile.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class DesignPage : ContentPage
  {
    public List<string> strList { get; set; }
    public DesignPage()
    {
      strList = new List<string>();
      InitializeComponent();
      GenertateGrid();      

      //texterman.Text = "There are smiles around the other corner.";      

    }
    public void OnButtonClicked(Object sender, EventArgs e)
    {
      Image img = sender as Image;
      strList.Add(img.Id.ToString());
      Debug.WriteLine($"IMAGE ID: {img.Id}  Source: {img.Source}");
      string imgSource = img.Source.ToString().Split()[1];
      
      if (imgSource == "nodeUnselect.png")
      {
        Debug.WriteLine($"B {img.Source}");
        img.Source = ImageSource.FromFile("nodeSelect.png");
        Debug.WriteLine($"A {img.Source}");
      }
      else if (imgSource == "nodeSelect.png")
      {
        Debug.WriteLine($"B {img.Source}");
        img.Source = img.Source = ImageSource.FromFile("nodeUnselect.png");
        Debug.WriteLine($"A {img.Source}");
      }
      OnPropertyChanged(nameof(img));



      Console.WriteLine();
    }
    public void GenertateGrid()
    {
      //nGrid = new Grid();   
      for (int i = 0; i < 8; i++)
      {
        nGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

      }
      for (int j = 0; j < 16; j++)
      {
        nGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
      }     
      for (int r = 0; r < 16; r++)
      {
        for (int c = 0; c < 8; c++)
        {
          nGrid.Children.Add(AddImageSource(r, c), c, r);          
        }
      }    

      Button button = new Button
      {
       Text = "Press to Save",
       BackgroundColor = (Color)Application.Current.Resources["Primary"],
       TextColor = Color.White
      };
      //button.Clicked += OnButtonClicked;
      nGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto)});
      nGrid.Children.Add(button,0,16);
      Grid.SetColumnSpan(button, 8);

      
      //Console.WriteLine();
    }
    public View AddImageSource(int row, int col)
    {
      //< Image Source = "nodeUnselect.png"
      //         VerticalOptions = "Center"
      //      HorizontalOptions = "Center"
      //         Grid.Row = "0"
      //      Grid.Column = "1" />
      Image img = new Image
      {
        StyleId = $"img-R{row}C{col}",
        VerticalOptions = LayoutOptions.Center,
        HorizontalOptions = LayoutOptions.Center,
        Source = "nodeUnselect.png",
      };
      TapGestureRecognizer tappy = new TapGestureRecognizer();
      tappy.Tapped += OnButtonClicked;
      img.GestureRecognizers.Add(tappy);
      
      return img;
    }

  }
}