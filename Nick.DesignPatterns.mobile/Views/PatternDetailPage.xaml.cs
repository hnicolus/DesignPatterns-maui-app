using DesignPatterns.Utils;
using DesignPatterns.ViewModels;

namespace DesignPatterns.Views
{
    public partial class PatternDetailPage : ContentPage, ITransientService
    {
        public PatternDetailPage(PatternDetailPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}

