using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesignPatterns.Services;

namespace DesignPatterns.ViewModels;

public partial class HomePageViewModel : ObservableObject, ITransientDependency
{
    private readonly DesignPatternsService _designPatternsService;

    [ObservableProperty] private List<Category> _categories = new();

    [ObservableProperty] private string _title = "Design Patterns";

    public HomePageViewModel(DesignPatternsService patternsService)
    {
        _designPatternsService = patternsService;
        Task.Run(LoadCategoriesAsync);
    }

    [RelayCommand]
    private async Task OpenPatternsAsync(int categoryId)
    {
        await Shell.Current.GoToAsync($"patterns?CategoryId={categoryId}");
    }


    public async Task LoadCategoriesAsync()
    {
        Categories = await _designPatternsService.GetCategoriesAsync();
    }
}