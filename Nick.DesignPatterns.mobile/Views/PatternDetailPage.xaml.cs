using System;
using DesignPatterns.Models;
using DesignPatterns.ViewModels;

namespace DesignPatterns.Views
{
    [QueryProperty(nameof(PatternId), "PatternId")]
    public partial class PatternDetailPage : ContentPage
    {
        private int patternId;

        public int PatternId
        {
            get => patternId; set
            {
                patternId = value;
                OnPropertyChanged();
            }
        }

        public PatternDetailPage(PatternDetailPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await (BindingContext as PatternDetailPageViewModel).LoadPatternAsync(PatternId);
        }
    }
}

