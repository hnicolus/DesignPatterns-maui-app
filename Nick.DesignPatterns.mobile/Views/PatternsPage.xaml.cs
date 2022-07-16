using DesignPatterns.Models;
using DesignPatterns.Utils;
using DesignPatterns.ViewModels;

namespace DesignPatterns.Views
{
    [QueryProperty(nameof(CategoryId), nameof(CategoryId))]
    public partial class PatternsPage : ContentPage, ITransientService
    {
        private int categoryId;

        public int CategoryId
        {
            get => categoryId;
            set
            {
                categoryId = value;
                OnPropertyChanged();
            }
        }
        public PatternsPage(PatternsPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as PatternsPageViewModel).LoadPatternsAsync(categoryId);
        }

        void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pattern pattern = (Pattern)(sender as CollectionView).SelectedItem;
            (BindingContext as PatternsPageViewModel).ShowDetailsCommand.Execute(pattern);
        }
    }
}

