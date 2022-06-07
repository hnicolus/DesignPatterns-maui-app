
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesignPatterns.Models;
using DesignPatterns.Services;

namespace DesignPatterns.ViewModels;

public partial class HomePageViewModel : ObservableObject
{
    private readonly IDesignPatternsService designPatternsService;

    [ObservableProperty]
    private List<Category> _categories = new();

    [ObservableProperty]
    private string _title = "Design Patterns";

    public HomePageViewModel(IDesignPatternsService patternsService )
    {
        designPatternsService = patternsService;
        Task.Run(LoadCategoriesAsync);
    }

    [ICommand]
    async Task OpenPatterns(int categoryId)
    {
      await Shell.Current.GoToAsync($"patterns?CategoryId={categoryId}");
    }

    public async Task LoadCategoriesAsync()
    {
        Title = "Design Patterns";
        Categories = await designPatternsService.GetCategoriesAsync();
    }
}