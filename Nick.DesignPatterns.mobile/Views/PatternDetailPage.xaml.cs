using DesignPatterns.ViewModels;

namespace DesignPatterns.Views;

public partial class PatternDetailPage : ContentPage, ITransientDependency
{
    public PatternDetailPage(PatternDetailPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}