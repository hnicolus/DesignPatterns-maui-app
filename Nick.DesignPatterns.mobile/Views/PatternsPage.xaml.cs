using DesignPatterns.ViewModels;

namespace DesignPatterns.Views
{
    [QueryProperty(nameof(CategoryId), "CategoryId")]
    public partial class PatternsPage : ContentPage
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
    }
}

