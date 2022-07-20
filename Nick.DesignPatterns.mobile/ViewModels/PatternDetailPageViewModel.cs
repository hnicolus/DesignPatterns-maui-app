using CommunityToolkit.Mvvm.ComponentModel;

namespace DesignPatterns.ViewModels;

public partial class PatternDetailPageViewModel : ObservableObject, IQueryAttributable, ITransientDependency
{
    [ObservableProperty] private Pattern _pattern;

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Pattern = (Pattern)query[nameof(Pattern)];
    }
}