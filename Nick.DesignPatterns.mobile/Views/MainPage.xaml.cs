using DesignPatterns.Utils;
using DesignPatterns.ViewModels;

namespace DesignPatterns.Views;

public partial class MainPage : ContentPage, ITransientService
{
	public MainPage(HomePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    void CollectionView_SelectionChanged(Object sender, SelectionChangedEventArgs e)
    {
	    (sender as CollectionView).UpdateSelectedItems(null);
		(sender as CollectionView).SelectedItem = null;
		(sender as CollectionView).SelectedItems = null;
	}
}


