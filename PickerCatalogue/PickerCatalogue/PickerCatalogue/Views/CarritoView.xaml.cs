using PickerCatalogue.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PickerCatalogue.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CarritoView : ContentPage
	{
		public CarritoView ()
		{
            BindingContext = new CarritoViewModel(Navigation);

            InitializeComponent();
        }
    }
}