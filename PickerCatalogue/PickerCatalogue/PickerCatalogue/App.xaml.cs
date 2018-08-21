using PickerCatalogue.Models;
using PickerCatalogue.Views;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace PickerCatalogue
{
	public partial class App : Application
	{
        //public INavigation Navigation { get; set; }

        public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new PickerView(new ObservableCollection<GuitarModel>()));
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
