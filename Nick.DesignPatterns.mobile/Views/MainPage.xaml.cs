using DesignPatterns.ViewModels;

namespace DesignPatterns.Views;

public partial class MainPage : ContentPage, ITransientDependency
{
    public MainPage(HomePageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        (sender as CollectionView).UpdateSelectedItems(null);
        (sender as CollectionView).SelectedItem = null;
        (sender as CollectionView).SelectedItems = null;
    }
}