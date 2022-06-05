using DesignPatterns.ViewModels;

namespace DesignPatterns;

public partial class MainPage : ContentPage
{
	public MainPage(HomePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    void CollectionView_SelectionChanged(System.Object sender, Microsoft.Maui.Controls.SelectionChangedEventArgs e)
    {
        categoriesCollection.UpdateSelectedItems(null);

		(sender as CollectionView).SelectedItem = null;
		(sender as CollectionView).SelectedItems = null;


	}
}


