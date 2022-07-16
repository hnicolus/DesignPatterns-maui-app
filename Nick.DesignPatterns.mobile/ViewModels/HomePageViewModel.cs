
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesignPatterns.Models;
using DesignPatterns.Services;
using DesignPatterns.Utils;

namespace DesignPatterns.ViewModels;

public partial class HomePageViewModel : ObservableObject, ITransientService
{
    readonly DesignPatternsService designPatternsService;

    [ObservableProperty]
    List<Category> _categories = new();

    [ObservableProperty]
    string _title = "Design Patterns";

    public HomePageViewModel(DesignPatternsService patternsService)
    {
        designPatternsService = patternsService;
        Task.Run(LoadCategoriesAsync);
    }

    [RelayCommand]
    async Task OpenPatternsAsync(int categoryId)
        => await Shell.Current.GoToAsync($"patterns?CategoryId={categoryId}");
    

    public async Task LoadCategoriesAsync()
        => Categories = await designPatternsService.GetCategoriesAsync();
}