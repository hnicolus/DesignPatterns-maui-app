using System;
using DesignPatterns.ViewModels;

namespace DesignPatterns.Views
{
	public partial class AboutPage: ContentPage
	{
		public AboutPage(AboutPageViewModel vm)
		{
			InitializeComponent();
			BindingContext = vm;
		}
	}
}

