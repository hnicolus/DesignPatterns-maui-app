using DesignPatterns.ViewModels;

namespace DesignPatterns.Views;

[QueryProperty(nameof(CategoryId), nameof(CategoryId))]
public partial class PatternsPage : ContentPage, ITransientDependency
{
    private int _categoryId;

    public PatternsPage(PatternsPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    public int CategoryId
    {
        get => _categoryId;
        set
        {
            _categoryId = value;
            OnPropertyChanged();
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await (BindingContext as PatternsPageViewModel).LoadPatternsAsync(_categoryId);
    }

    private void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var pattern = (Pattern)(sender as CollectionView).SelectedItem;
        (BindingContext as PatternsPageViewModel).ShowDetailsCommand.Execute(pattern);
    }
}