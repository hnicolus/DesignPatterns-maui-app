using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesignPatterns.Models;
using DesignPatterns.Services;
using DesignPatterns.Utils;
using DesignPatterns.Views;

namespace DesignPatterns.ViewModels;

public partial class PatternsPageViewModel : ObservableObject, ITransientService
{
    readonly DesignPatternsService designPatternsService;

    [ObservableProperty]
    List<Pattern> _patterns;

    [ObservableProperty]
    Category _category;

    public PatternsPageViewModel(DesignPatternsService patternsService)
    {
        designPatternsService = patternsService;
    }

    [RelayCommand]
    public async Task ShowDetails(Pattern pattern)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { nameof(Pattern), pattern }
        };

        await Shell.Current.GoToAsync(nameof(PatternDetailPage), navigationParameter);
    }

    public async Task LoadPatternsAsync(int categoryId)
    {
        Category = await designPatternsService.GetCategoryAsync(categoryId);
        Patterns = await designPatternsService.GetCategoryPatternsAsync(categoryId);
    }
}

