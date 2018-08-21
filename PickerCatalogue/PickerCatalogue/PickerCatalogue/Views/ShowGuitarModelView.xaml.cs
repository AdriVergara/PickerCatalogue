using PickerCatalogue.ViewModels;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using PickerCatalogue.Models;
using CarouselView.FormsPlugin.Abstractions;

namespace PickerCatalogue.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShowGuitarModelView : ContentPage
	{
		public ShowGuitarModelView (GuitarModel guit, INavigation Navigation)
		{
            BindingContext = new ShowGuitarModelViewModel(guit, Navigation);

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