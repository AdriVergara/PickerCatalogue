using PickerCatalogue.Models;
using PickerCatalogue.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PickerCatalogue.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PickerView : ContentPage
	{
        //private ObservableCollection<GuitarModel> CarritoModels = new ObservableCollection<GuitarModel>();

        public PickerView (ObservableCollection<GuitarModel> _carritoModels)
		{
            BindingContext = new PickerViewModel(Navigation, _carritoModels);

			InitializeComponent();
		}
	}
}