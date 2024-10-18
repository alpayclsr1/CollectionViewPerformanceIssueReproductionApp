using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CollectionViewPerformanceIssueReproductionApp;

public partial class MainPageViewModel:ObservableObject
{
      private const int TotalItems = 1000;
    private const int ItemsPerBatch = 22;

    [ObservableProperty]
    private ObservableCollection<Item> items=new ObservableCollection<Item>();

    public MainPageViewModel()
    {
        LoadMoreItems(); // Load initial items
    }

    [RelayCommand]
    private void LoadMoreItems()
    {
        var currentCount = Items.Count;
        
       
        for (int i = currentCount; i < currentCount + ItemsPerBatch && i < TotalItems; i++)
        {
            Items.Add(new Item
            {
                Id = i,
                Text = $" Sample Item: {i + 1}", 
                HeaderImageSource = "sample1.png" 
            });
        }
    }


}

public class Item
{
    public int Id { get; set; }
    public required string Text { get; set; }
    public required string HeaderImageSource { get; set; }
}
