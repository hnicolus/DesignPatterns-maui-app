using System;
using System.Diagnostics;
using DesignPatterns.Utils;
using DesignPatterns.ViewModels;

namespace DesignPatterns.Views
{
	public partial class AboutPage: ContentPage, ITransientService
    {
		public AboutPage(AboutPageViewModel vm)
		{
			InitializeComponent();
			BindingContext = vm;
		}
	}
}

