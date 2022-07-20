using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DesignPatterns.Services;
using DesignPatterns.Views;

namespace DesignPatterns.ViewModels;

public partial class PatternsPageViewModel : ObservableObject, ITransientDependency
{
    private readonly DesignPatternsService _designPatternsService;

    [ObservableProperty] private Category _category;

    [ObservableProperty] private List<Pattern> _patterns;

    public PatternsPageViewModel(DesignPatternsService patternsService)
    {
        _designPatternsService = patternsService;
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
        Category = await _designPatternsService.GetCategoryAsync(categoryId);
        Patterns = await _designPatternsService.GetCategoryPatternsAsync(categoryId);
    }
}