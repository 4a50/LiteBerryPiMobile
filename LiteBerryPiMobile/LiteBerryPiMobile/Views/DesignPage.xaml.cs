using LiteBerryPiMobile.Models;
using LiteBerryPiMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LiteBerryPiMobile.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]

  public partial class DesignPage : ContentPage
  {
    public List<string> selectedNodes { get; set; }
    public List<Image> imageNodeList { get; set; }
    readonly DesignViewModel _dvm;
    public DesignPage()
    {
      BindingContext = _dvm = new DesignViewModel(); //<--DI?
      selectedNodes = new List<string>();
      imageNodeList = new List<Image>();
      InitializeComponent();
      GenertateGrid();

    }
    public void OnNodeClicked(Object sender, EventArgs e)
    {
      Image img = sender as Image;
      //TODO: Fix Ugly way to get if image was selected or not.  Maybe use the database?  To many DBase calls?

      string imgSource = img.Source.ToString().Split()[1];

      if (imgSource == "nodeUnselect.png")
      {
        img.Source = ImageSource.FromFile("nodeSelect.png");
        selectedNodes.Add(img.StyleId);

      }
      else if (imgSource == "nodeSelect.png")
      {
        img.Source = img.Source = ImageSource.FromFile("nodeUnselect.png");
        try { selectedNodes.Remove(img.StyleId); }
        catch { Console.WriteLine("No Entry Exsists!"); }
      }
      Debug.WriteLine("strList:");
      foreach (string s in selectedNodes) { Debug.Write(s); }
      Debug.WriteLine("endList");
      OnPropertyChanged(nameof(img));

    }
    public void OnButtonClicked(Object sender, EventArgs e)
    {
      Debug.WriteLine(e.ToString());
      Button btn = sender as Button;
      switch (btn.StyleId)
      {
        case "reset-button":
          ResetNodes();
          break;
        case "save-button":
          SaveNodesToDataBase();

          break;
        default:
          Console.WriteLine("Obj Called Does Not Meet Any Case");
          break;
      }
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
      Button saveButton = new Button
      {
        StyleId = "save-button",
        Text = "Press to Save",
        BackgroundColor = (Color)Application.Current.Resources["Primary"],
        TextColor = Color.White
      };
      saveButton.Clicked += OnButtonClicked;
      nGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
      nGrid.Children.Add(saveButton, 0, 16);
      Grid.SetColumnSpan(saveButton, 6);

      Button resetButton = new Button
      {
        StyleId = "reset-button",
        Text = "Reset",
        BackgroundColor = Color.Red,
        TextColor = Color.White
      };
      resetButton.Clicked += OnButtonClicked;
      nGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
      nGrid.Children.Add(resetButton, 6, 16);
      Grid.SetColumnSpan(resetButton, 2);
    }
    public View AddImageSource(int row, int col)
    {
      Image img = new Image
      {
        StyleId = $"img-R{row}C{col}",
        VerticalOptions = LayoutOptions.Center,
        HorizontalOptions = LayoutOptions.Center,
        Source = "nodeUnselect.png",
      };
      TapGestureRecognizer tappy = new TapGestureRecognizer();
      tappy.Tapped += OnNodeClicked;
      img.GestureRecognizers.Add(tappy);
      imageNodeList.Add(img);
      return img;
    }
    public void ResetNodes()
    {
      foreach (Image im in imageNodeList)
      {
        im.Source = ImageSource.FromFile("nodeUnselect.png");
      };
    }
    async void SaveNodesToDataBase()
    {
      try
      {
         string designName = await DisplayPromptAsync("Save LiteBerry Design", "Choose A Name to Save This Under");
        _dvm.Save(selectedNodes, designName);
        LBData printEntry = await _dvm.GetWithDesignName(designName);
        Debug.WriteLine($"Entry Made: {printEntry.DesignName} Coords: {printEntry.NodeCoord}");

        
      }
      catch(Exception e) { Debug.WriteLine(e.Message); }
    }
  }
}