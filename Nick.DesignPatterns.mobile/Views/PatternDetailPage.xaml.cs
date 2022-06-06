﻿using DesignPatterns.ViewModels;

namespace DesignPatterns.Views
{
    public partial class PatternDetailPage : ContentPage
    {
        public PatternDetailPage(PatternDetailPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}

