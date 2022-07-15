
using CommunityToolkit.Mvvm.ComponentModel;
using DesignPatterns.Models;
using DesignPatterns.Utils;

namespace DesignPatterns.ViewModels;

public partial class PatternDetailPageViewModel : ObservableObject, IQueryAttributable, ITransientService
{

    [ObservableProperty]
    Pattern _pattern;

    public void ApplyQueryAttributes(IDictionary<string, object> query)
        => Pattern = query[nameof(Pattern)] as Pattern;
}

