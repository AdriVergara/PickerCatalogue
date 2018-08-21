using PickerCatalogue.ViewModels;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using PickerCatalogue.Models;
using CarouselView.FormsPlugin.Abstractions;
using System.Collections.ObjectModel;

namespace PickerCatalogue.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShowGuitarModelView : ContentPage
	{
		public ShowGuitarModelView (INavigation _navigation, GuitarModel _modelSelected, ObservableCollection<GuitarModel> _carritoModels)
		{
            BindingContext = new ShowGuitarModelViewModel(_navigation, _modelSelected, _carritoModels);

            InitializeComponent();
		}

        public void CarouselImages_Scrolled(object sender, CarouselView.FormsPlugin.Abstractions.ScrolledEventArgs e)
        {
            var DirectionSwiped = (e.Direction).ToString();
            double NewCarouselValue = e.NewValue;

            //var vm = new ShowGuitarModelViewModel(null, null);
        }
    }
}