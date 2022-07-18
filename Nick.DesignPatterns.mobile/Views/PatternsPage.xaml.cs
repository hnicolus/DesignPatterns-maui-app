using DesignPatterns.Models;
using DesignPatterns.Utils;
using DesignPatterns.ViewModels;

namespace DesignPatterns.Views
{
    [QueryProperty(nameof(CategoryId), nameof(CategoryId))]
    public partial class PatternsPage : ContentPage, ITransientService
    {
        private int _categoryId;

        public int CategoryId
        {
            get => _categoryId;
            set
            {
                _categoryId = value;
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
            await ((PatternsPageViewModel)BindingContext).LoadPatternsAsync(CategoryId);
        }

        void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pattern = (Pattern)((CollectionView)sender).SelectedItem;
            ((PatternsPageViewModel)BindingContext).ShowDetailsCommand.Execute(pattern);
        }
    }
}

